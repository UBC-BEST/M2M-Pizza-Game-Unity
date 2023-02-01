using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] GameObject _PizzaInstructions;

    public void onPizzaStopped() {
        _PizzaInstructions.SetActive(true);
    }

    public void onPizzaSent() {
        _PizzaInstructions.SetActive(false);
    }
}
