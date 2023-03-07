/*
    Script for Pizza Body
    Controls the movement and sprites of the pizza. 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Numerics;

public class PizzaScript : MonoBehaviour
{
    public Rigidbody2D pizzaBody;
    public SpriteRenderer spriteRenderer;
    public Sprite[] pizzaSprites;

    public float velocityMagnitude = 10f;
    public float angularVelocityMagnitude = 50f;
    bool stoppedAlready = false;
    UnityEngine.Vector2 startingPosition = new UnityEngine.Vector2(-20, -1.5f);
    public float spriteNumber;

    bool pepperoni = false;
    bool sausage = false;
    bool greenpeppers = false;
    bool olives = false;

    void Start()
    {
        spriteRenderer.sprite = pizzaSprites[0];
        pizzaBody.position = startingPosition;
        DOTween.SetTweensCapacity(500, 50);
        transform.DOMoveX(0.0f, 2.0f)
            .SetEase(Ease.InOutSine);
        transform.DORotate(new UnityEngine.Vector3(0.0f, 0.0f, 200.0f), 2.0f, RotateMode.FastBeyond360)
            .SetEase(Ease.InOutSine);
    }

    void Update()
    {
        PizzaMovement();

        if (stoppedAlready == true)
        {
            if (Input.GetKeyDown(KeyCode.P) == true)
            {
                pepperoni = true;
            }
            if (Input.GetKeyDown(KeyCode.S) == true)
            {
                sausage = true;
            }
            if (Input.GetKeyDown(KeyCode.G) == true)
            {
                greenpeppers = true;
            }
            if (Input.GetKeyDown(KeyCode.O) == true)
            {
                olives = true;
            }

            PizzaSpriteControl();
        }
        ScreenWrapAroundControl();

    }

    /*
        Checks if the pizza has reached the center of the screen. If so, then stop the pizza. 
        Once the pizza is stopped, the space key can be pressed to send the pizza off with its initial velocities again. 
    */
    void PizzaMovement()
    {
        if (pizzaBody.position == startingPosition)
        {
            DOTween.SetTweensCapacity(500, 50);
            transform.DOMoveX(0.0f, 2.0f)
            .SetEase(Ease.OutSine);
            transform.DORotate(new UnityEngine.Vector3(0.0f, 0.0f, 200.0f), 2.0f, RotateMode.FastBeyond360)
               .SetEase(Ease.OutSine);
        }

        if (pizzaBody.position.x >= 0 && stoppedAlready == false)
        {
            pizzaBody.velocity = UnityEngine.Vector2.zero;
            stoppedAlready = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) == true && stoppedAlready == true)
        {
            transform.DOMoveX(20.0f, 2.0f)
                .SetEase(Ease.InSine);
            transform.DORotate(new UnityEngine.Vector3(0.0f, 0.0f, 360.0f), 2.0f, RotateMode.FastBeyond360)
                .SetEase(Ease.InSine);
        }

    }

    /*
        Controls the sprites of the pizza depending on the states of the four booleans:
            pepperoni, sausage, greenpeppers, and olives 
    */
    void PizzaSpriteControl()
    {
        if (pepperoni == false && sausage == false && greenpeppers == false && olives == false)
        {
            spriteRenderer.sprite = pizzaSprites[0];
            spriteNumber = 0;
        }
        if (pepperoni == true && sausage == false && greenpeppers == false && olives == false)
        {
            spriteRenderer.sprite = pizzaSprites[1];
            spriteNumber = 1;
        }
        if (pepperoni == false && sausage == true && greenpeppers == false && olives == false)
        {
            spriteRenderer.sprite = pizzaSprites[2];
            spriteNumber = 2;
        }
        if (pepperoni == false && sausage == false && greenpeppers == true && olives == false)
        {
            spriteRenderer.sprite = pizzaSprites[3];
            spriteNumber = 3;
        }
        if (pepperoni == false && sausage == false && greenpeppers == false && olives == true)
        {
            spriteRenderer.sprite = pizzaSprites[4];
            spriteNumber = 4;
        }
        if (pepperoni == true && sausage == true && greenpeppers == false && olives == false)
        {
            spriteRenderer.sprite = pizzaSprites[5];
            spriteNumber = 5;
        }
        if (pepperoni == true && sausage == false && greenpeppers == true && olives == false)
        {
            spriteRenderer.sprite = pizzaSprites[6];
            spriteNumber = 6;
        }
        if (pepperoni == true && sausage == false && greenpeppers == false && olives == true)
        {
            spriteRenderer.sprite = pizzaSprites[7];
            spriteNumber = 7;
        }
        if (pepperoni == false && sausage == true && greenpeppers == true && olives == false)
        {
            spriteRenderer.sprite = pizzaSprites[8];
            spriteNumber = 8;
        }
        if (pepperoni == false && sausage == true && greenpeppers == false && olives == true)
        {
            spriteRenderer.sprite = pizzaSprites[9];
            spriteNumber = 9;
        }
        if (pepperoni == false && sausage == false && greenpeppers == true && olives == true)
        {
            spriteRenderer.sprite = pizzaSprites[10];
            spriteNumber = 10;
        }
        if (pepperoni == true && sausage == true && greenpeppers == true && olives == false)
        {
            spriteRenderer.sprite = pizzaSprites[11];
            spriteNumber = 11;
        }
        if (pepperoni == true && sausage == true && greenpeppers == false && olives == true)
        {
            spriteRenderer.sprite = pizzaSprites[12];
            spriteNumber = 12;
        }
        if (pepperoni == true && sausage == false && greenpeppers == true && olives == true)
        {
            spriteRenderer.sprite = pizzaSprites[13];
            spriteNumber = 13;
        }
        if (pepperoni == false && sausage == true && greenpeppers == true && olives == true)
        {
            spriteRenderer.sprite = pizzaSprites[14];
            spriteNumber = 14;
        }
        if (pepperoni == true && sausage == true && greenpeppers == true && olives == true)
        {
            spriteRenderer.sprite = pizzaSprites[15];
            spriteNumber = 15;
        }

    }

    /*
     * Gets the sprite number
     */
    public float GetSpriteNumber()
    {
        return (spriteNumber);
    }

    /*
        If the pizza moves off the right edge of the screen, teleport it to before the left edge of the screen. 
    */
    void ScreenWrapAroundControl()
    {
        if (pizzaBody.position.x >= 20)
        {
            stoppedAlready = false;
            spriteRenderer.sprite = pizzaSprites[0];

            pepperoni = false;
            sausage = false;
            greenpeppers = false;
            olives = false;
            transform.DOMoveX(-20.0f, 0.0f);
            pizzaBody.position = startingPosition;
        }
    }
}
