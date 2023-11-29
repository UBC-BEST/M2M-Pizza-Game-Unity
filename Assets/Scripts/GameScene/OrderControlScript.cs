using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// Order control script to generate and check orders. <br/> 
/// Interfaces with the <b>OrderTicket</b> object.
/// </summary>
public class OrderControlScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D ticketBody;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] ticketSprites; 
    [SerializeField] PizzaScript pizzaScript;
    [SerializeField] GameEvent ScoreUp, PizzaOffScreen;

    [SerializeField] Vector2 startingPosition = new Vector2(-6, 6.5f);  
    [SerializeField] Vector2 endPosition = new Vector2(-6, 4.0f);
    [SerializeField] float moveTime = 1.0f;
    
    private bool orderExists = false; 
    private int orderNumber = 1;
    
    /// <summary>
    /// Move the order ticket to the specified starting position, with z=0. 
    /// </summary>
    void Start() {
        transform.DOMove(startingPosition, 0);
    }

    /// <summary>
    /// Check if an order must be generated, and set the correct sprite for the ticket. 
    /// </summary>
    void Update() {
        OrderSpawner();
        OrderSpriteControl();
    }

    /// <summary>
    /// Generate a random integer in a specified range (inclusive). 
    /// </summary>
    /// <param name="min">Minimum integer</param>
    /// <param name="max">Maximum integer</param>
    /// <returns>A random integer within the specified range.</returns>
    int randomNumberInRange(int min, int max) {
        System.Random random = new System.Random();
        int generatedNumber = random.Next(min, max + 1);
        return generatedNumber;
    }

    /// <summary>
    /// Control function for generating an order and moving the order ticket down. 
    /// </summary>
    void OrderSpawner() { 
        if (!orderExists && ticketBody.position == startingPosition) {
            orderNumber = randomNumberInRange(1, 15);
            transform.DOMove(endPosition, moveTime).SetEase(Ease.InOutSine);
            orderExists = true;
        }
    }

    /// <summary>
    /// Sprite control for order ticket. <br/>
    /// <b>TODO: The -1 is necessary to avoid IndexOutOfBounds once the orderNumber variable is created. Please fix</b>
    /// </summary>
    void OrderSpriteControl() {
        spriteRenderer.sprite = ticketSprites[orderNumber - 1];
    }

    /// <summary>
    /// Checks the order to determine if the placed toppings match the order, and assign score accordingly. <br/>
    /// After, moves the order ticket up (off the screen). <br/>
    /// Interfaces with the <b>PizzaOffScreen</b> event.
    /// </summary>
    public void OnPizzaOffScreen() {
        orderExists = false;
        transform.DOMove(startingPosition, moveTime).SetEase(Ease.InSine);
    }

    public bool[] GetOrderNumber() {
        bool[] toppings = {false, false, false, false};   // P = 0, S = 1, G = 2, O = 3 (the index of each topping)

        if (orderNumber == 1 || orderNumber == 5 || orderNumber == 6 || orderNumber == 7 || 
            orderNumber == 11 || orderNumber == 12 || orderNumber == 13 || orderNumber == 15) toppings[0] = true; 

        if (orderNumber == 2 || orderNumber == 5 || orderNumber == 8 || orderNumber == 9 || 
            orderNumber == 11 || orderNumber == 12 || orderNumber == 14 || orderNumber == 15) toppings[1] = true; 

        if (orderNumber == 3 || orderNumber == 6 || orderNumber == 8 || orderNumber == 10 || 
            orderNumber == 11 || orderNumber == 13 || orderNumber == 14 || orderNumber == 15) toppings[2] = true; 

        if (orderNumber == 4 || orderNumber == 7 || orderNumber == 9 || orderNumber == 10 || 
            orderNumber == 12 || orderNumber == 13 || orderNumber == 14 || orderNumber == 15) toppings[3] = true; 

        return toppings; 
    }
}
