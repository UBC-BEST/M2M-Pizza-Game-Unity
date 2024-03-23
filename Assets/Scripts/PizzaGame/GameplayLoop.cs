using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayLoop : MonoBehaviour
{
    [SerializeField] private GameObject order, pizza, toppingSpawner;
    [SerializeField] public TextMeshProUGUI scoreText;
    private List<GameObject> toppingListCopy;
    private bool gameLoopRunning, _pizzaAtMiddle, _pizzaSent, _pizzaOffScreen;
    private int _score;
    

    private void Update()
    {
        if (!gameLoopRunning) 
        {
            Debug.Log("Game loop started.");
            Debug.Log(Screen.width);
            Debug.Log(Screen.height);
            StartCoroutine(GameLoop());
            gameLoopRunning = true;
        }
    }

    private IEnumerator GameLoop()
    {
        order.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        
        pizza.SetActive(true);
        yield return new WaitUntil(() => _pizzaAtMiddle);
        _pizzaAtMiddle = false;
        
        toppingSpawner.SetActive(true);
        yield return new WaitUntil(() => _pizzaSent);
        _pizzaSent = false;
        
        toppingListCopy = toppingSpawner.GetComponent<ToppingSpawnerScript>().toppingList;
        toppingSpawner.SetActive(false);
        yield return new WaitUntil(() => _pizzaOffScreen);
        _pizzaOffScreen = false;
        
        pizza.SetActive(false);
        order.SetActive(false);
        DeleteToppings();

        _score++;
        scoreText.text = "Score: " + _score;
        yield return new WaitForSeconds(1.0f);

        gameLoopRunning = false;
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
