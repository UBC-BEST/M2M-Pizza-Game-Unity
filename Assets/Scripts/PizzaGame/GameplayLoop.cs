using System.Collections;
using UnityEngine;
using TMPro;

public class GameplayLoop : MonoBehaviour
{
    [SerializeField] private GameObject order, pizza, toppingSpawner;
    [SerializeField] public TextMeshProUGUI scoreText;
    private bool gameLoopRunning, _pizzaAtMiddle, _pizzaSent, _pizzaOffScreen;
    private int _score;

    private void Update()
    {
        if (!gameLoopRunning) 
        {
            Debug.Log("Game loop started.");
            StartCoroutine(GameLoop());
            gameLoopRunning = true;
        }
    }

    private IEnumerator GameLoop()
    {
        Debug.Log("Order awaken requested.");
        order.SetActive(true);
        yield return new WaitForSeconds(0.5f);

        Debug.Log("Pizza awaken requested.");
        pizza.SetActive(true);
        yield return new WaitUntil(() => _pizzaAtMiddle);
        _pizzaAtMiddle = false;
        
        toppingSpawner.SetActive(true);
        Debug.Log("Topping spawner awake.");
        yield return new WaitUntil(() => _pizzaSent);
        _pizzaSent = false;
        
        toppingSpawner.SetActive(false);
        Debug.Log("Topping spawner asleep.");
        yield return new WaitUntil(() => _pizzaOffScreen);
        _pizzaOffScreen = false;
        
        pizza.SetActive(false);
        Debug.Log("Pizza asleep.");
        order.SetActive(false);
        Debug.Log("Order ticket asleep.");

        _score++;
        scoreText.text = "Score: " + _score;
        yield return new WaitForSeconds(1.0f);

        gameLoopRunning = false;
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
