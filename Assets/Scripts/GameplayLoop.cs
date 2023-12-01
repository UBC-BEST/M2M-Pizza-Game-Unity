using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameplayLoop : MonoBehaviour
{
    [SerializeField] private GameObject order, pizza;
    private bool _gameLoopRunning, _pizzaSent, _pizzaOffScreen = false;
    private int score = 0;
    
    // to do: this is not a loop - make it infinite without crashing lol 
    public void GameStart()
    {
        if (_gameLoopRunning) return;
        _gameLoopRunning = true;
        StartCoroutine(GameLoop());
    }

    private IEnumerator GameLoop()
    {
        order.SetActive(true);
        yield return new WaitForSeconds(0.75f);

        pizza.SetActive(true);
        yield return new WaitUntil(() => _pizzaSent);
        
        // to do - check toppings
        yield return new WaitUntil(() => _pizzaOffScreen);

        pizza.SetActive(false);
        order.SetActive(false);
        
        // to do - if toppings are correct, add score 
        score++;
        yield return new WaitForSeconds(0.5f);

        _gameLoopRunning = false;
    }

    public void PizzaSent()
    {
        _pizzaSent = true; 
    }

    public void PizzaOffScreen()
    {
        _pizzaOffScreen = true;
    }
}
