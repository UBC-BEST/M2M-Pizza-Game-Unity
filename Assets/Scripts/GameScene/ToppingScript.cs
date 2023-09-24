using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// WIP - Wesley is currently working on this, dont touch!!! <br/>
/// or ill overwrite all your code on github 
/// </summary>
public class ToppingScript : MonoBehaviour
{
    [SerializeField] GameObject pepperoniPrefab;
    [SerializeField] GameObject sausagePrefab;
    [SerializeField] GameObject greenPepperPrefab;
    [SerializeField] GameObject olivePrefab; 
    private Vector2 spawnPos = new Vector2(0, 0);
    private List<GameObject> allToppings = new List<GameObject>();

    /// <summary>
    /// Set the tags for each topping prefab to "Topping". 
    /// </summary>
    void Start() {
        pepperoniPrefab.tag = "Topping"; 
        sausagePrefab.tag = "Topping"; 
        greenPepperPrefab.tag = "Topping"; 
        olivePrefab.tag = "Topping"; 
    }

    /// <summary>
    /// Spawn the specific topping when the corresponding key is pressed. 
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
            SpawnToppings('P');
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            SpawnToppings('S');
        }
        if (Input.GetKeyDown(KeyCode.G)) {
            SpawnToppings('G');
        }
        if (Input.GetKeyDown(KeyCode.O)) {
            SpawnToppings('O');
        }
    }

    /// <summary>
    /// Given the first letter of a topping, instantiates 20 of that topping randomly onto the pizza. <br/>
    /// TODO: clean up the code, make it more efficient, actually spawn them in a circle, lock the toppings' position to the pizza. 
    /// </summary>
    /// <param name="name">The name of the topping. Must either be 'P', 'S', 'G', or 'O', otherwise the code does nothing.</param>
    void SpawnToppings(char name) {
        switch(name) {
            case 'P':
                for (int i = 0; i < 20; i++) {
                    spawnPos = new Vector2(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f));
                    var toppingInstance = Instantiate(pepperoniPrefab, spawnPos, Quaternion.Euler(0, 0, Random.Range(-180.0f, 180.0f)));
                    allToppings.Add(toppingInstance);
                }
                break;
            case 'S':
                for (int i = 0; i < 20; i++) {
                    spawnPos = new Vector2(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f));
                    var toppingInstance = Instantiate(sausagePrefab, spawnPos, Quaternion.Euler(0, 0, Random.Range(-180.0f, 180.0f)));
                    allToppings.Add(toppingInstance);
                }
                break;
            case 'G': 
                for (int i = 0; i < 20; i++) {
                    spawnPos = new Vector2(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f));
                    var toppingInstance = Instantiate(greenPepperPrefab, spawnPos, Quaternion.Euler(0, 0, Random.Range(-180.0f, 180.0f)));
                    allToppings.Add(toppingInstance);
                }
                break;
            case 'O': 
                for (int i = 0; i < 20; i++) {
                    spawnPos = new Vector2(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f));
                    var toppingInstance = Instantiate(olivePrefab, spawnPos, Quaternion.Euler(0, 0, Random.Range(-180.0f, 180.0f)));
                    allToppings.Add(toppingInstance);
                }
                break;
        }
    }

    /// <summary>
    /// Function to destroy all toppings present in the scene. <br/>
    /// TODO: bugged; only destroys one topping and then throws an InvalidOperationException. Fix ASAP
    /// </summary>
    public void DestroyToppings() {
        foreach(var instance in allToppings) {
            allToppings.Remove(instance);
            Destroy(instance);
        }
    }
}

