using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaInstructionsScript : MonoBehaviour
{
    public Rigidbody2D pizzaInstructionsBody;

    void OnEnable()
    {
        pizzaInstructionsBody.position = new Vector2(0, -2);
    }

    void OnDisable()
    {
        
    }
}
