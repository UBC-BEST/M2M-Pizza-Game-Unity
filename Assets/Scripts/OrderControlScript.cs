using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderControlScript : MonoBehaviour
{
    bool orderExists = false; 
    bool orderCleared = false; 
    int points = 0;
    
    /*
        lol
        generate a random number in a range inclusive
    */
    public int randomNumberInRange(int min, int max) {
        System.Random random = new System.Random();
        int orderNumber = random.Next(min, max + 1);
        return orderNumber;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // set position of order tickets
        // wait a few seconds (delay in first order) 
    }

    // Update is called once per frame
    void Update()
    {
        if (!orderExists) {
            // generate a new order
        }

        if (orderCleared) {
            points++; 
            // hide the order from the screen before deleting the order
            // wait a few (random amount of) seconds before allowing the check if the order does not exist, so the new order doesn't show up instantly
        }
        
        // once the spacebar is pressed (send the pizza), check what toppings the pizza has
        // if the toppings match the order, put a flag to clear the order
        // if the toppings do not match the order, pizza still gets sent, but nothing happens to the order 
    }
}
