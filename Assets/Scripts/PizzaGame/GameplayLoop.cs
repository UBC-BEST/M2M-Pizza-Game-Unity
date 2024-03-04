using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayLoop : MonoBehaviour
{
    private const float STRIKE_TIMEOUT_S = 10.0f;
    private const int NUM_STRIKES_ALLOWED = 3;
    
    [SerializeField] private GameObject order, pizza, toppingSpawner;
    [SerializeField] public TextMeshProUGUI scoreText;
    private List<GameObject> toppingListCopy;
    private bool _gameLoopRunning, _gameEnded, _pizzaAtMiddle, _pizzaSent, _pizzaOffScreen;
    private int _score, _numToppings, _numStrikes;
    private float _strikeTime;
    private Coroutine gameLoop;
    

    private void Update()
    {
        if (!_gameLoopRunning && !_gameEnded) 
        {
            Debug.Log("Game loop started.");
            _numStrikes = 0;
            gameLoop = StartCoroutine(GameLoop());
            _gameLoopRunning = true;
        }

        if (_gameEnded)
        {
            Debug.Log("Game over.");
        }
    }

    private IEnumerator GameLoop()
    {
        // wake order
        order.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        
        // wake pizza, wait until pizza is at middle 
        pizza.SetActive(true);
        yield return new WaitUntil(() => _pizzaAtMiddle);
        _pizzaAtMiddle = false;
        
        // wake topping spawner, wait until pizza is sent, strikes for time 
        toppingSpawner.SetActive(true);
        _strikeTime = STRIKE_TIMEOUT_S; 
        
        /*
        while (!_pizzaSent)
        {
            _strikeTime -= Time.deltaTime;
            
            if (_strikeTime <= 0.0f)
            {
                _numStrikes++;
                Debug.Log("Strike added.");
                _strikeTime = STRIKE_TIMEOUT_S;
            }

            if (_numStrikes >= NUM_STRIKES_ALLOWED)
            {
                _gameEnded = true;
                yield break; 
            }
        }
        */
        
        yield return new WaitUntil(() => _pizzaSent);
        _pizzaSent = false;
        
        // get list of toppings, wait until pizza is off screen
        toppingListCopy = toppingSpawner.GetComponent<ToppingSpawnerScript>().toppingList;
        _numToppings = toppingListCopy.Count;
        toppingSpawner.SetActive(false);
        yield return new WaitUntil(() => _pizzaOffScreen);
        _pizzaOffScreen = false;
        
        // sleep pizza, order; delete toppings 
        pizza.SetActive(false);
        order.SetActive(false);
        DeleteToppings();

        // increment score, reset game loop 
        _score = _score + _numToppings;
        scoreText.text = "Score: " + _score;
        yield return new WaitForSeconds(1.0f);
        _gameLoopRunning = false;
    }

    private void DeleteToppings()
    {
        foreach (GameObject topping in toppingListCopy)
        {
            Destroy(topping);
        }

        toppingListCopy.Clear();
    }
    
    public void PizzaSent()
    {
        _pizzaSent = true; 
    }

    public void PizzaOffScreen()
    {
        _pizzaOffScreen = true;
    }

    public void PizzaAtMiddle()
    {
        _pizzaAtMiddle = true;
    }
}
