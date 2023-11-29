using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTextScript : MonoBehaviour
{
    [SerializeField] OrderControlScript orderControlScript; 
    [SerializeField] GameEvent ScoreUp; 
    private bool pepperoni = false;
    private bool sausage = false;
    private bool greenPepper = false;
    private bool olive = false;
    private bool[] toppings; 

    void OnPizzaOffScreen() {
        toppings = orderControlScript.GetOrderNumber();

        if (toppings[0] == pepperoni &&
            toppings[1] == sausage &&
            toppings[2] == greenPepper &&
            toppings[3] == olive) {
                ScoreUp.TriggerEvent();
            }
    }
    
    void indexTopping() {
        pepperoni = true;
    }

    void middleTopping() {
        sausage = true; 
    }

    void ringTopping() {
        greenPepper = true;
    }

    void PinkyTopping() {
        olive = true; 
    }
}
