/*
    Script for pizza
    Controls the movement and sprites of the pizza. 

    TODO: pizza should no longer need different sprites for toppings. 
        Instead, that will be handled by the topping scripts. 
        We may want more sprites later for animation stuff in the future. 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class PizzaScript : MonoBehaviour {
    [SerializeField] GameObject Pizza;
    [SerializeField] Rigidbody2D pizzaBody;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] pizzaSprites; 

    [SerializeField] GameEvent PizzaStopped;
    [SerializeField] GameEvent PizzaSent;
    [SerializeField] GameEvent PizzaOffScreen;
    [SerializeField] Vector2 startingPosition = new Vector2(-20, -1.5f);

    private bool stoppedAlready = false;
    private int spriteNumber = 0;
    private bool pepperoni = false;
    private bool sausage = false;
    private bool greenpeppers = false;
    private bool olives = false;
    
    void Start() {
        spriteRenderer.sprite = pizzaSprites[0];
        pizzaBody.position = startingPosition;
    }

    void Update() {
        PizzaMovement();
        ScreenWrapAroundControl();

        if (stoppedAlready) {
            InputControl();
            SpriteControl();
        }
    }

    void PizzaMovement() {
        if (pizzaBody.position == startingPosition) {
            DOTween.SetTweensCapacity(500, 50);
            transform.DOMoveX(0.0f, 2.0f)
                .SetEase(Ease.InOutSine);
            transform.DORotate(new Vector3(0.0f, 0.0f, 200.0f), 2.0f, RotateMode.FastBeyond360)
                .SetEase(Ease.InOutSine);
        }
        
        if (pizzaBody.position.x >= 0 && !stoppedAlready) 
        {
            pizzaBody.velocity = Vector2.zero;
            stoppedAlready = true;
            PizzaStopped.TriggerEvent();
        }

        if (Input.GetKeyDown(KeyCode.Space) && stoppedAlready) 
        {
            PizzaSent.TriggerEvent();
            transform.DOMoveX(20.0f, 2.0f)
                .SetEase(Ease.InSine);
            transform.DORotate(new Vector3(0.0f, 0.0f, 360.0f), 2.0f, RotateMode.FastBeyond360)
                .SetEase(Ease.InSine);
        }
    }

    void SpriteControl() {
        if (pepperoni == false && sausage == false && greenpeppers == false && olives == false) {
            spriteNumber = 0;
        }
        if (pepperoni == true && sausage == false && greenpeppers == false && olives == false) {
            spriteNumber = 1;
        }
        if (pepperoni == false && sausage == true && greenpeppers == false && olives == false) {
            spriteNumber = 2;
        }
        if (pepperoni == false && sausage == false && greenpeppers == true && olives == false) {
            spriteNumber = 3;
        }
        if (pepperoni == false && sausage == false && greenpeppers == false && olives == true) {
            spriteNumber = 4;
        }
        if (pepperoni == true && sausage == true && greenpeppers == false && olives == false) {
            spriteNumber = 5;
        }
        if (pepperoni == true && sausage == false && greenpeppers == true && olives == false) {
            spriteNumber = 6;
        }
        if (pepperoni == true && sausage == false && greenpeppers == false && olives == true) {
            spriteNumber = 7;
        }
        if (pepperoni == false && sausage == true && greenpeppers == true && olives == false) {
            spriteNumber = 8;
        }
        if (pepperoni == false && sausage == true && greenpeppers == false && olives == true) {
            spriteNumber = 9;
        }
        if (pepperoni == false && sausage == false && greenpeppers == true && olives == true) {
            spriteNumber = 10;
        }
        if (pepperoni == true && sausage == true && greenpeppers == true && olives == false) {
            spriteNumber = 11;
        }
        if (pepperoni == true && sausage == true && greenpeppers == false && olives == true) {
            spriteNumber = 12;
        }
        if (pepperoni == true && sausage == false && greenpeppers == true && olives == true) {
            spriteNumber = 13;
        }
        if (pepperoni == false && sausage == true && greenpeppers == true && olives == true) {
            spriteNumber = 14;
        }
        if (pepperoni == true && sausage == true && greenpeppers == true && olives == true) {
            spriteNumber = 15;
        }

        spriteRenderer.sprite = pizzaSprites[spriteNumber];
    }

    void ScreenWrapAroundControl() {
        if (pizzaBody.position.x >= 20) {
            stoppedAlready = false; 
            spriteRenderer.sprite = pizzaSprites[0];

            pepperoni = false;
            sausage = false;
            greenpeppers = false;
            olives = false;

            transform.DOMoveX(-20.0f, 0.0f);
            pizzaBody.position = startingPosition;

            PizzaOffScreen.TriggerEvent();
        }
    }

    void InputControl() {
        if (Input.GetKeyDown(KeyCode.P)) {
            pepperoni = true;
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            sausage = true;
        }
        if (Input.GetKeyDown(KeyCode.G)) {
            greenpeppers = true;
        }
        if (Input.GetKeyDown(KeyCode.O)) {
            olives = true;
        }
    }

    public int GetSpriteNumber() {
        return spriteNumber;
    }
}
