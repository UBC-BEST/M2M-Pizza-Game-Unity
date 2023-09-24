using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for the instructions that show up on the <b>Game Scene</b>. <br/>
/// TODO: This will likely be deleted once we have a proper background and tutorial. 
/// </summary>
public class PizzaInstructionsScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D pizzaInstructionsBody;
    [SerializeField] Vector2 startingPosition = new Vector2(0, 3.6f);

    /// <summary>
    /// Move the instructions to the specified starting position. 
    /// </summary>
    void Start()
    {
        pizzaInstructionsBody.position = startingPosition;
    }
}
