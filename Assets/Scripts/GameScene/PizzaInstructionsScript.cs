/*
    Script for instructions that show up on the Game Scene.
    Hopefully if we make it look nicer it won't look awful. 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaInstructionsScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D pizzaInstructionsBody;
    [SerializeField] Vector2 startingPosition = new Vector2(0, 3.6f);

    void Start()
    {
        pizzaInstructionsBody.position = startingPosition;
    }
}
