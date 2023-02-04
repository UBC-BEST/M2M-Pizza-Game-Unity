using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] GameObject _PizzaInstructions;
    [SerializeField] GameObject _Pizza;
    public TextMeshProUGUI scoreText;

    public GameEvent CheckOrder;

    private int score;

    void Start() {
        score = 0;
        scoreText.text = "Score: " + score;
    }

    void Update() {
        scoreText.text = "Score: " + score;
    }

    public void PizzaOffScreen() {
        CheckOrder.TriggerEvent();
    }

    public void OnScoreUp() {
        score++;
    }
}
