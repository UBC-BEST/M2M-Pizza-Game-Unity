/*
    Overarching manager for the pizza game, used by the GameManager object.

    TODO: I want this object to hold most of the functionality of the game. This game manager object should...
        1) Create and check the orders
        2) Control timing of when the order comes in, pizza spinning into the screen, etc
        3) Have basic difficulty level parameters, to use later when we have prior user data, so we can adjust timing, score multiplier, etc
        4) Ensure correct starting and stopping of the game
        5) Awaken and sleep objects (particularly toppings) as necessary 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] GameObject _PizzaInstructions;
    [SerializeField] GameObject _Pizza;
    [SerializeField] GameObject _Topping;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] GameEvent CheckOrder;

    private int score;

    void Start() {
        score = 0;
        scoreText.text = "Score: " + score;
        // put toppings to sleep
    }

    void Update() {
        scoreText.text = "Score: " + score;
    }

    public void OnPizzaOffScreen() {
        CheckOrder.TriggerEvent();
    }

    public void OnScoreUp() {
        score++;
    }

    // on PizzaStopped, enable toppings
    // on PizzaSent, toppings should move (in the toppings script)
}
