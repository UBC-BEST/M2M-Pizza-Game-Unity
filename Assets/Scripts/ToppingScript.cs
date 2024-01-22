using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingScript : MonoBehaviour
{
    [SerializeField] private GameObject pizza;
    [SerializeField] private Rigidbody2D topping;
    private Vector3 positionOffset;
    private var rotation;

    void Start()
    {
        positionOffset = new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f), 0);
        rotation = Quaternion.Euler(0, 0, Random.Range(-180.0f, 180.0f));
    }
    
    void Update()
    {
        topping.transform.position = pizza.transform.rotation * positionOffset + pizza.transform.position;
        topping.transform.rotation = pizza.transform.rotation + rotation;
    }
}
