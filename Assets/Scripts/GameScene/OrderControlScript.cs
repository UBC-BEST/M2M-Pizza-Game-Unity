/*
    Order control script used by the order ticket object to 
    generate and check orders. 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderControlScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D ticketBody;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] ticketSprites; 
    [SerializeField] PizzaScript pizzaScript;

    [SerializeField] GameEvent OrderReady;
    [SerializeField] GameEvent ScoreUp;

    [SerializeField] float yUpPosition = 6.5f;
    [SerializeField] float yDownPosition = 4.0f;
    [SerializeField] Vector2 startingPosition = new Vector2(-6, 6.5f);  
    [SerializeField] float velocityMagnitude = 3f;
    
    private bool orderExists = false; 
    private bool orderDisplayed = false;
    private int orderNumber = 0;
    
    void Start() {
        ticketBody.position = startingPosition;
        ticketBody.velocity = Vector2.zero;
    }

    void Update() {
        if (!orderExists) {
            OrderSpawner();
        }
        
        OrderSpriteControl();
        OrderMovementControl();
    }

    /*
        generate a random number in a range inclusive
    */
    int randomNumberInRange(int min, int max) {
        System.Random random = new System.Random();
        int orderNumber = random.Next(min, max + 1);
        return orderNumber;
    }

    void OrderSpawner() { 
        orderNumber = randomNumberInRange(1, 15);
        orderDisplayed = false;
        orderExists = true;
        OrderReady.TriggerEvent();
    }

    void OrderSpriteControl() {
        spriteRenderer.sprite = ticketSprites[orderNumber - 1];
    }

    void OrderMovementControl() {
        if (ticketBody.position.y > yDownPosition && !orderDisplayed) { 
            ticketBody.velocity = Vector2.down * velocityMagnitude;
        }
        if (ticketBody.position.y <= yDownPosition && !orderDisplayed) {
            ticketBody.velocity = Vector2.zero;
            orderDisplayed = true; 
        }
        if (ticketBody.position.y >= yUpPosition && orderDisplayed) {
            ticketBody.velocity = Vector2.zero;
            orderExists = false;
            orderDisplayed = false;
        }
    }

    public void CheckOrder() {
        if (orderNumber == pizzaScript.GetSpriteNumber()) {
            ScoreUp.TriggerEvent();
        }

        ticketBody.velocity = Vector2.up * velocityMagnitude;
    }
}
