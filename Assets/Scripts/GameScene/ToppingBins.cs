
// using UnityEngine;

// public class ToppingBin : MonoBehaviour
// {
//     public GameObject toppingPrefab; // Reference to the prefab you want to instantiate
//     public int numberOfToppings = 4; // Number of toppings to instantiate
//     public float distanceBetweenToppings = 2f; // Distance between each instantiated topping
//     public float distanceFromScreenSides = 2f; // Distance from the sides of the screen


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingBinsScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D pepperoniBin;
    [SerializeField] Rigidbody2D oliveBin;
    [SerializeField] Rigidbody2D greenPepperBin;
    [SerializeField] Rigidbody2D sausageBin;
    [SerializeField] Vector2 startingPositionO = new Vector2(-3.3f, 6.5f);
    [SerializeField] Vector2 startingPositionP = new Vector2(-0.5f, 6.5f);
    [SerializeField] Vector2 startingPositionS = new Vector2(2.3f, 6.5f);
    [SerializeField] Vector2 startingPositionG = new Vector2(5.1f, 6.5f);
    [SerializeField] Vector2 endPositionO = new Vector2(-3.3f, 3.4f);
    [SerializeField] Vector2 endPositionP = new Vector2(-0.5f, 3.4f); 
    [SerializeField] Vector2 endPositionS = new Vector2(2.3f, 3.4f); 
    [SerializeField] Vector2 endPositionG = new Vector2(5.1f, 3.4f); 


        void Start()
    {
        StartCoroutine(MoveBin(oliveBin, startingPositionO, endPositionO));
        StartCoroutine(MoveBin(pepperoniBin, startingPositionP, endPositionP));
        StartCoroutine(MoveBin(sausageBin, startingPositionS, endPositionS));
        StartCoroutine(MoveBin(greenPepperBin, startingPositionG, endPositionG));
    }

    IEnumerator MoveBin(Rigidbody2D rigidbody, Vector2 start, Vector2 end)
    {
        rigidbody.MovePosition(start);

        float startTime = Time.time;
        float duration = 1.0f; // Adjust the duration as needed

        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            rigidbody.MovePosition(Vector2.Lerp(start, end, t));
            yield return null;
        }

        rigidbody.MovePosition(end);
    }


    //     void Start()
    // {
    //     SetInitialPosition(oliveBin, startingPositionO);
    //     SetInitialPosition(pepperoniBin, startingPositionP);
    //     SetInitialPosition(sausageBin, startingPositionS);
    //     SetInitialPosition(greenPepperBin, startingPositionG);
    // }

    // void SetInitialPosition(Rigidbody2D rigidbody, Vector2 position)
    // {
    //     rigidbody.MovePosition(position);
    // }



    // void Start()
    // {
    //     pepperoniBin.transform.position = startingPositionP;
    //     oliveBin.transform.position = startingPositionO;
    //     greenPepperBin.transform.position = startingPositionG;
    //     sausageBin.transform.position = startingPositionS;
    // }
}
