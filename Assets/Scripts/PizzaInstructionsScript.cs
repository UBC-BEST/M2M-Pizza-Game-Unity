using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaInstructionsScript : MonoBehaviour
{
    public Rigidbody2D pizzaInstructionsBody;
    public Vector2 startingPosition = new Vector2(0, 3.6f);

    void Start()
    {
        pizzaInstructionsBody.position = startingPosition;
    }
}
