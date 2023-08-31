/*
    Overarching manager for the pizza game, used by the GameManager object.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] GameObject _PizzaInstructions, _Pizza, _Topping;
    [SerializeField] TextMeshProUGUI scoreText;

    private int score;

    void Start() {
        score = 0;
        scoreText.text = "Score: " + score;
        // put toppings to sleep
    }

    void Update() {
        scoreText.text = "Score: " + score;
    }

    public void OnScoreUp() {
        score++;
    }

    // on PizzaStopped, enable toppings
    // on PizzaSent, toppings should move (in the toppings script)
}
