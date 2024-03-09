using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayLoop : MonoBehaviour
{
    [SerializeField] private GameObject order, pizza, toppingSpawner;
    [SerializeField] public TextMeshProUGUI scoreText;
    private List<GameObject> toppingListCopy;
    private bool gameLoopRunning, pizzaAtMiddle, pizzaSent, pizzaOffScreen;
    private int score, numToppings;
    
    private void Update()
    {
        if (!gameLoopRunning) 
        {
            Debug.Log("Game loop started.");
            StartCoroutine(GameLoop());
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
    
    private IEnumerator PlacingToppings() {
        toppingSpawner.SetActive(true);

        // timer 
        yield return new WaitUntil(() => pizzaSent);
        
        pizzaSent = false;
        yield break;
    }

    private IEnumerator SendPizza()
    {
        toppingSpawner.SetActive(false);
        yield return new WaitUntil(() => pizzaOffScreen);
        
        pizzaOffScreen = false;
        pizza.SetActive(false);
        order.SetActive(false);
        
        toppingListCopy = toppingSpawner.GetComponent<ToppingSpawnerScript>().toppingList;
        numToppings = toppingListCopy.Count;
        DeleteToppings();

        score = score + numToppings;
        scoreText.text = "Score: " + score;

        yield break;
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
