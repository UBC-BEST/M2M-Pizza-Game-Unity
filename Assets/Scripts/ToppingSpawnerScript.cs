using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingSpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject pepperoni, sausage, greenPepper, olive;
    private List<GameObject> toppingPrefabList = new List<GameObject>();
    
    public void SpawnPepperoni()
    {
        for (int i = 0; i < 20; i++) SpawnTopping(pepperoni);
    }
    
    public void SpawnSausage()
    {
        for (int i = 0; i < 20; i++) SpawnTopping(sausage);
    }
    
    public void SpawnGreenPepper()
    {
        for (int i = 0; i < 20; i++) SpawnTopping(greenPepper);
    }
    
    public void SpawnOlive()
    {
        for (int i = 0; i < 20; i++) SpawnTopping(olive);
    }

    private void SpawnTopping(GameObject topping)
    {
        float r = UnityEngine.Random.Range(0, 2.0f);
        float theta = UnityEngine.Random.Range(0, (float) (2 * Math.PI));
        float x = (float) (r * Math.Cos(theta));
        float y = (float) (r * Math.Sin(theta));
        
        Vector2 spawnPos = new Vector3(x, y, 0.0f);
        var toppingInstance = Instantiate(topping, spawnPos, Quaternion.Euler(0, 0, UnityEngine.Random.Range(-180.0f, 180.0f)));
        toppingPrefabList.Add(toppingInstance);
    }
}
