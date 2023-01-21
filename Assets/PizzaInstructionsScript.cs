using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaInstructionsScript : MonoBehaviour
{
    public Rigidbody2D pizzaInstructionsBody;
    
    // Start is called before the first frame update
    void Start()
    {
        pizzaInstructionsBody.position = new Vector2(0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
