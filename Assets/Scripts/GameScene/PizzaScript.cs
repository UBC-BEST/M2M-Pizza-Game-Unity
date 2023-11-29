using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using static System.Runtime.CompilerServices.RuntimeHelpers;

/// <summary>
/// Pizza class, which controls the behaviour of the pizza (without toppings). <br/>
/// TODO: Much of the functionality of this script will be moved to ToppingSpawner once implemented. 
/// </summary>
public class PizzaScript : MonoBehaviour {
    [SerializeField] GameObject Pizza;
    [SerializeField] Rigidbody2D pizzaBody;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] pizzaSprites; 
    [SerializeField] GameEvent PizzaStopped, PizzaSent, PizzaOffScreen;
    [SerializeField] Vector2 startingPosition = new Vector2(-20, -1.5f);
    [SerializeField] float moveTime = 2.0f; 

    private bool stoppedAlready = false;
    
    /// <summary>
    /// Set the sprite of the Pizza to the default sprite, and move it to the starting position. 
    /// </summary>
    void Start() {
        spriteRenderer.sprite = pizzaSprites[0];
        transform.DOMove(startingPosition, 0);
    }

    /// <summary>
    /// Constantly update the pizza's movement. If the pizza is stopped at the center of the screen, allow for keyboard input and sprite changes. 
    /// </summary>
    void Update() {
        PizzaMovement();
        ScreenWrapAroundControl();
    }

    /// <summary>
    /// Function to control the movement of the pizza. <br/> 
    /// Triggers the <b>PizzaStopped</b> event when the pizza is in the middle of the screen. <br/> 
    /// Triggers the <b>PizzaSent</b> event when the Space key is pressed (after <b>PizzaStopped</b> has been triggered). 
    /// </summary>
    void PizzaMovement() {
        if (pizzaBody.position == startingPosition) {
            transform.DOMoveX(0.0f, moveTime).SetEase(Ease.InOutSine);
            transform.DORotate(new Vector3(0.0f, 0.0f, 180.0f), moveTime, RotateMode.FastBeyond360).SetEase(Ease.InOutSine);
        }
        
        if (pizzaBody.position.x >= 0 && !stoppedAlready) 
        {
            stoppedAlready = true;
            PizzaStopped.TriggerEvent();
        }

        if (Input.GetKeyDown(KeyCode.Space) && stoppedAlready) 
        {
            PizzaSent.TriggerEvent();
            transform.DOMoveX(20.0f, moveTime).SetEase(Ease.InSine);
            transform.DORotate(new Vector3(0.0f, 0.0f, 360.0f), moveTime, RotateMode.FastBeyond360).SetEase(Ease.InSine);
        }
    }

    /// <summary>
    /// Function that makes sure the pizza resets its sprite and position after it moves a specified distance off the right of the screen.
    /// </summary>
    void ScreenWrapAroundControl() {
        if (pizzaBody.position.x >= 20) {
            spriteRenderer.sprite = pizzaSprites[0];
            stoppedAlready = false; 

            transform.DOMove(startingPosition, 0);
            PizzaOffScreen.TriggerEvent();
        }
    }
}
