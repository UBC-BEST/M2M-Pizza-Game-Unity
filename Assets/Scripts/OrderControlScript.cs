using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class OrderControlScript : MonoBehaviour
{
    public Rigidbody2D ticketBody;
    public SpriteRenderer spriteRenderer;
    public Sprite[] ticketSprites; 
    public PizzaScript pizzaScript;

    public GameEvent OrderReady;
    public GameEvent ScoreUp;

    public float baseHeight = 256f;
    public Vector3 startingPosition;
    public Vector3 originalScale, screenScale;    
    public float velocityMagnitude = 3f;
    public float yUpPosition = 6.5f;
    public float yDownPosition = 6.0f;
    
    bool orderExists = false; 
    bool orderDisplayed = false;
    int orderNumber = 0;
    
    void Start() {
        GetScaled();
        startingPosition = new Vector3(-Screen.height/(2*baseHeight) - 4.5f, Screen.height/(2*baseHeight) + 6.5f, 0.0368f);
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
            //ticketBody.velocity = Vector2.down * velocityMagnitude;  
            DOTween.SetTweensCapacity(500, 50);
            transform.DOMoveY(yDownPosition, 2.0f)
                .SetEase(Ease.InOutSine);
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

    public void GetScaled() 
    {
        yDownPosition = Screen.height - 6.5f;
        screenScale = new Vector3(baseHeight/Screen.width, baseHeight/Screen.height, 1f);
        transform.DOScale(screenScale, 0f);
    } 
}
