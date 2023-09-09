/*
    Order control script used by the order ticket object to 
    generate and check orders. 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
    
    void Start() {
        transform.DOMove(startingPosition, 0);
    }

    void Update() {
        OrderSpawner();
        OrderSpriteControl();
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
        if (!orderExists && ticketBody.position == startingPosition) {
            orderNumber = randomNumberInRange(1, 15);
            transform.DOMove(endPosition, moveTime).SetEase(Ease.InOutSine);
            orderExists = true;
        }
    }

    void OrderSpriteControl() {
        spriteRenderer.sprite = ticketSprites[orderNumber - 1];
    }

    public void OnPizzaOffScreen() {
        orderExists = false;
        
        if (orderNumber == pizzaScript.GetSpriteNumber()) {
            ScoreUp.TriggerEvent();
        }

        transform.DOMove(startingPosition, moveTime).SetEase(Ease.InSine);
    }
}
