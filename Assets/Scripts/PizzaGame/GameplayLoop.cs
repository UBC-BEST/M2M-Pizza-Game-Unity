using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayLoop : MonoBehaviour
{
    private const float STRIKE_TIME = 10.0f; 
    private const int MAX_STRIKES = 3;
    
    [SerializeField] private GameObject order, pizza, toppingSpawner;
    [SerializeField] public TextMeshProUGUI scoreText;
    private List<GameObject> toppingListCopy;
    private bool gameLoopRunning, pizzaAtMiddle, pizzaSent, pizzaOffScreen, gameEnd;
    private int score, numToppings, numStrikes;
    private float timer;
    
    private void Update()
    {
        if (!gameLoopRunning && !gameEnd) 
        {
            Debug.Log("Game loop started.");
            StartCoroutine(GameLoop());
        }

        if (gameEnd) 
        {
            Debug.Log("lol u suck");
            Debug.Log("nerd");
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
        timer = STRIKE_TIME;
        
        while (!pizzaSent) 
        {
            yield return StartCoroutine(StrikeTimer());
        }
        yield return new WaitUntil(() => pizzaSent);

        pizzaSent = false;
        yield break;
    }

    private IEnumerator StrikeTimer()
    {
        timer -= Time.deltaTime;

        if (timer <= 0.0f) 
        {
            numStrikes++;
            timer = STRIKE_TIME;
            Debug.Log("Strike administered. Number of strikes: " + numStrikes);
        }

        if (numStrikes >= 3) 
        {
            gameEnd = true;
            pizzaSent = true;
            Debug.Log("Game ended.");
        }

        yield return null;
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
