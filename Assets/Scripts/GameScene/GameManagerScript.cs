using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Script for the invisible GameManager object, which oversees scoring and event calling. <br/>
/// TODO: More functionality regarding event broadcasts, game adjustments, etc will be moved to this function. 
/// </summary>
public class GameManagerScript : MonoBehaviour
{
    [SerializeField] GameObject _PizzaInstructions, _Pizza, _Topping;
    [SerializeField] TextMeshProUGUI scoreText;

    private int score;

    /// <summary>
    /// Set the score to 0, and display the score text. 
    /// </summary>
    void Start() {
        score = 0;
        scoreText.text = "Score: " + score;
        // put toppings to sleep
    }

    /// <summary>
    /// Update the score text to show the current score. 
    /// </summary>
    void Update() {
        scoreText.text = "Score: " + score;
    }

    /// <summary>
    /// Public function to increase the score, when the toppings match the order. <br/>
    /// <b>OrderControlScript</b> broadcasts this event. 
    /// </summary>
    public void OnScoreUp() {
        score++;
    }
}
