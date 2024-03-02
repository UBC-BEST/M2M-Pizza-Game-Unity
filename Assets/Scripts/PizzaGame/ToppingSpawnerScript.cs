using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingSpawnerScript : MonoBehaviour
{
    [SerializeField] GameObject pepperoni, sausage, greenPepper, olive;
    public List<GameObject> toppingList;

    private void OnEnable()
    {
        toppingList = new List<GameObject>();
    }
    
    public void SpawnPepperoni()
    {
        SpawnTopping(pepperoni);
    }
    
    public void SpawnSausage()
    {
        SpawnTopping(sausage);
    }
    
    public void SpawnGreenPepper()
    {
        SpawnTopping(greenPepper);
    }
    
    public void SpawnOlive()
    {
        SpawnTopping(olive);
    }

    private void SpawnTopping(GameObject topping)
    {
        var toppingInstance = Instantiate(topping, new Vector2(1.6f, -1.2f), 
            Quaternion.Euler(0, 0, UnityEngine.Random.Range(-180.0f, 180.0f)));
        toppingList.Add(toppingInstance);
    }
}
