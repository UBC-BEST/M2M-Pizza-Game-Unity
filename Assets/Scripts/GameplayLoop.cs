using System.Collections;
using UnityEngine;

public class GameplayLoop : MonoBehaviour
{
    [SerializeField] private GameObject order, pizza, toppingSpawner;
    [SerializeField] private GameEvent startGameLoop;
    private bool _pizzaAtMiddle, _pizzaSent, _pizzaOffScreen;
    private int _score;

    public void StartGameLoop()
    {
        StartCoroutine(GameLoop());
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
        
        toppingSpawner.SetActive(false);
        yield return new WaitUntil(() => _pizzaOffScreen);
        _pizzaOffScreen = false;
        
        pizza.SetActive(false);
        order.SetActive(false);

        _score++;
        yield return new WaitForSeconds(1.0f);
        
        startGameLoop.TriggerEvent();
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
