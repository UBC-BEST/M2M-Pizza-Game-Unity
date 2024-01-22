using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingSpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject pepperoni, sausage, greenPepper, olive;
    private Vector2 spawnPos;
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
        var toppingInstance = Instantiate();
        toppingPrefabList.Add(toppingInstance);
    }
}
