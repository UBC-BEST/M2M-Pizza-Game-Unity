using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    private bool pepperoniSpawned = false;
    private bool sausageSpawned = false;
    private bool greenPepperSpawned = false;
    private bool oliveSpawned = false;

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
        if (Input.GetKeyDown(KeyCode.P) && !pepperoniSpawned) {         
            SpawnToppings('P');
        }
        if (Input.GetKeyDown(KeyCode.S) && !sausageSpawned) {
            SpawnToppings('S');
        }
        if (Input.GetKeyDown(KeyCode.G) && !greenPepperSpawned) {
            SpawnToppings('G');
        }
        if (Input.GetKeyDown(KeyCode.O) && !oliveSpawned) {
            SpawnToppings('O');
        }
    }

    /// <summary>
    /// Given the first letter of a topping, instantiates 20 of that topping randomly onto the pizza. <br/>
    /// Spawns toppings a minimum distance away from each other. <br/> 
    /// Does not allow topping spawning if that topping has already been spawned. <br/>
    /// TODO: lock the toppings' position to the pizza. 
    /// </summary>
    /// <param name="name">The name of the topping. Must either be 'P', 'S', 'G', or 'O', otherwise the code does nothing.</param>
    void SpawnToppings(char name) {
        Vector2[] spawnPosList = new Vector2[20];
        
        for (int i = 0; i < 20; i++) {
            float spawnRadius = UnityEngine.Random.Range(0f, 2f);
            float spawnAngle = UnityEngine.Random.Range(0f, 359f);
            spawnPos = new Vector2(spawnRadius * (float)Math.Cos(spawnAngle), spawnRadius * (float)Math.Sin(spawnAngle) - 1.5f);
            spawnPosList[i] = spawnPos;
            // verify if the topping is spawned some distance away 
        }

        switch(name) {
            case 'P':
                foreach(Vector2 position in spawnPosList) {
                    var toppingInstance = Instantiate(pepperoniPrefab, position, Quaternion.Euler(0, 0, UnityEngine.Random.Range(-180.0f, 180.0f)));
                    allToppings.Add(toppingInstance);
                }
                pepperoniSpawned = true;
                break;
            case 'S':
                foreach(Vector2 position in spawnPosList) {
                    var toppingInstance = Instantiate(sausagePrefab, position, Quaternion.Euler(0, 0, UnityEngine.Random.Range(-180.0f, 180.0f)));
                    allToppings.Add(toppingInstance);
                }
                sausageSpawned = true;
                break;
            case 'G': 
                foreach(Vector2 position in spawnPosList) {
                    var toppingInstance = Instantiate(greenPepperPrefab, position, Quaternion.Euler(0, 0, UnityEngine.Random.Range(-180.0f, 180.0f)));
                    allToppings.Add(toppingInstance);
                }
                greenPepperSpawned = true;
                break;
            case 'O': 
                foreach(Vector2 position in spawnPosList) {
                    var toppingInstance = Instantiate(olivePrefab, position, Quaternion.Euler(0, 0, UnityEngine.Random.Range(-180.0f, 180.0f)));
                    allToppings.Add(toppingInstance);
                }
                oliveSpawned = true;
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

