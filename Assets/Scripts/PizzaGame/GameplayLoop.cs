using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayLoop : MonoBehaviour
{
    private const float DURATION_MIN = 0.25f;
    private const float DURATION_S = DURATION_MIN * 60.0f;
    
    [SerializeField] private GameObject order, pizza, toppingSpawner;
    [SerializeField] public TextMeshProUGUI scoreText;
    private List<GameObject> toppingListCopy;
    private bool gameLoopRunning, pizzaAtMiddle, pizzaSent, pizzaOffScreen, gameEnd;
    private int score, numToppings;
    private float timer;

    private void OnEnable()
    {
        timer = DURATION_S;
    }
    
    private void Update()
    {
        GameDurationControl();
        
        if (!gameLoopRunning && !gameEnd) 
        {
            Debug.Log("Game loop started.");
            StartCoroutine(GameLoop());
        }
        
        if (gameEnd) 
        {
            // display end screen 
            order.SetActive(false);
            pizza.SetActive(false);
            toppingSpawner.SetActive(false);
        }
    }

    private IEnumerator GameLoop()
    {
        gameLoopRunning = true;
        yield return StartCoroutine(PizzaToMiddle());
        yield return StartCoroutine(PlacingToppings());
        yield return StartCoroutine(SendPizza());
        yield return new WaitForSeconds(1.0f);
        gameLoopRunning = false;
    }

    private IEnumerator PizzaToMiddle()
    {
        order.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        
        pizza.SetActive(true);
        yield return new WaitUntil(() => pizzaAtMiddle);
        
        pizzaAtMiddle = false;
        yield break;
    }
    
    private IEnumerator PlacingToppings() 
    {
        toppingSpawner.SetActive(true);
        yield return new WaitUntil(() => pizzaSent);

        pizzaSent = false;
        yield break;
    }

    private IEnumerator SendPizza()
    {
        toppingSpawner.SetActive(false);

        if (!gameEnd) 
        {
            yield return new WaitUntil(() => pizzaOffScreen);
        
            pizzaOffScreen = false;
            pizza.SetActive(false);
            order.SetActive(false);
        
            toppingListCopy = toppingSpawner.GetComponent<ToppingSpawnerScript>().toppingList;
            numToppings = toppingListCopy.Count;
            DeleteToppings(toppingListCopy);

            score = score + numToppings;
            scoreText.text = "Score: " + score;
        }
        else 
        {
            pizza.SetActive(false);
            order.SetActive(false);

            toppingListCopy = toppingSpawner.GetComponent<ToppingSpawnerScript>().toppingList;
            DeleteToppings(toppingListCopy);
        }

        yield break;
    }

    private void GameDurationControl()
    {
        timer -= Time.deltaTime;

        if (timer <= 0.0f)
        {
            gameEnd = true;
        }
    }

    private void DeleteToppings(List<GameObject> toppingList)
    {
        foreach (GameObject topping in toppingList)
        {
            Destroy(topping);
        }

        toppingList.Clear();
    }
    
    public void PizzaSent()
    {
        pizzaSent = true; 
    }

    public void PizzaOffScreen()
    {
        pizzaOffScreen = true;
    }

    public void PizzaAtMiddle()
    {
        pizzaAtMiddle = true;
    }
}
