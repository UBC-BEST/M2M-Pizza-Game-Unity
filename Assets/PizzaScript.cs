using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaScript : MonoBehaviour {
    public Rigidbody2D pizzaBody;
    public SpriteRenderer spriteRenderer;
    public Sprite[] pizzaSprites; 

    public float velocityMagnitude = 10f;
    public float angularVelocityMagnitude = 50f;
    bool stoppedAlready = false;
    Vector2 startingPosition = new Vector2(-20, -1);

    bool pepperoni = false;
    bool sausage = false;
    bool greenpeppers = false;
    bool olives = false;
    
    // Start is called before the first frame update
    void Start() {
        spriteRenderer.sprite = pizzaSprites[0];
        pizzaBody.position = startingPosition;
        pizzaBody.velocity = Vector2.right * velocityMagnitude;
        pizzaBody.angularVelocity = angularVelocityMagnitude;
    }

    // Update is called once per frame
    void Update() {
        PizzaMovement();

        if (stoppedAlready == true) {
            if (Input.GetKeyDown(KeyCode.P) == true) {
                pepperoni = true;
            }
            if (Input.GetKeyDown(KeyCode.S) == true) {
                sausage = true;
            }
            if (Input.GetKeyDown(KeyCode.G) == true) {
                greenpeppers = true;
            }
            if (Input.GetKeyDown(KeyCode.O) == true) {
                olives = true;
            }
            
            PizzaSpriteControl();
        }
        
        ScreenWrapAroundControl();
    }

    void PizzaMovement() {
        // stop pizza if it reaches the middle of the screen 
        if (pizzaBody.position.x > 0 && stoppedAlready == false) 
        {
            pizzaBody.velocity = Vector2.zero;
            pizzaBody.angularVelocity = 0;
            stoppedAlready = true;
        }

        // make pizza move again
        if (Input.GetKeyDown(KeyCode.Space) == true && stoppedAlready == true) 
        {
            pizzaBody.velocity = Vector2.right * velocityMagnitude;
            pizzaBody.angularVelocity = angularVelocityMagnitude;
        }
    }

    void PizzaSpriteControl() {
        if (pepperoni == false && sausage == false && greenpeppers == false && olives == false) {
            spriteRenderer.sprite = pizzaSprites[0];
        }
        if (pepperoni == true && sausage == false && greenpeppers == false && olives == false) {
            spriteRenderer.sprite = pizzaSprites[1];
        }
        if (pepperoni == false && sausage == true && greenpeppers == false && olives == false) {
            spriteRenderer.sprite = pizzaSprites[2];
        }
        if (pepperoni == false && sausage == false && greenpeppers == true && olives == false) {
            spriteRenderer.sprite = pizzaSprites[3];
        }
        if (pepperoni == false && sausage == false && greenpeppers == false && olives == true) {
            spriteRenderer.sprite = pizzaSprites[4];
        }
        if (pepperoni == true && sausage == true && greenpeppers == false && olives == false) {
            spriteRenderer.sprite = pizzaSprites[5];
        }
        if (pepperoni == true && sausage == false && greenpeppers == true && olives == false) {
            spriteRenderer.sprite = pizzaSprites[6];
        }
        if (pepperoni == true && sausage == false && greenpeppers == false && olives == true) {
            spriteRenderer.sprite = pizzaSprites[7];
        }
        if (pepperoni == false && sausage == true && greenpeppers == true && olives == false) {
            spriteRenderer.sprite = pizzaSprites[8];
        }
        if (pepperoni == false && sausage == true && greenpeppers == false && olives == true) {
            spriteRenderer.sprite = pizzaSprites[9];
        }
        if (pepperoni == false && sausage == false && greenpeppers == true && olives == true) {
            spriteRenderer.sprite = pizzaSprites[10];
        }
        if (pepperoni == true && sausage == true && greenpeppers == true && olives == false) {
            spriteRenderer.sprite = pizzaSprites[11];
        }
        if (pepperoni == true && sausage == true && greenpeppers == false && olives == true) {
            spriteRenderer.sprite = pizzaSprites[12];
        }
        if (pepperoni == true && sausage == false && greenpeppers == true && olives == true) {
            spriteRenderer.sprite = pizzaSprites[13];
        }
        if (pepperoni == false && sausage == true && greenpeppers == true && olives == true) {
            spriteRenderer.sprite = pizzaSprites[14];
        }
        if (pepperoni == true && sausage == true && greenpeppers == true && olives == true) {
            spriteRenderer.sprite = pizzaSprites[15];
        }
    }

    void ScreenWrapAroundControl() {
        // screen wraparound
        if (pizzaBody.position.x > -1 * startingPosition.x) 
        {
            pizzaBody.position = startingPosition;
            stoppedAlready = false; 
            spriteRenderer.sprite = pizzaSprites[0];

            pepperoni = false;
            sausage = false;
            greenpeppers = false;
            olives = false;
        }
    }
}
