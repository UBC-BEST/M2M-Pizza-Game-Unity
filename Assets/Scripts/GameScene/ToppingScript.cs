/*
    Script to control placement and movement of toppings. 
    
    TODO: current plan is to have topping prefabs created by this script, while the game 
        manager calls for the specific toppings to be placed. All 4 types of toppings 
        will use this script. 

        Instantiate toppings, select type, generate 20 random positions, lock to pizza 
        Destroy once pizza is off the screen 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingScript : MonoBehaviour
{
    [SerializeField] GameObject pepperoniPrefab;
    [SerializeField] GameObject sausagePrefab;
    [SerializeField] GameObject greenPepperPrefab;
    [SerializeField] GameObject olivePrefab; 
    private Vector2 spawnPos = new Vector2(0, 0);

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

    void SpawnToppings(char name) {
        switch(name) {
            case 'P':
                for (int i = 0; i < 20; i++) {
                    spawnPos = new Vector2(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f));
                    Instantiate(pepperoniPrefab, spawnPos, Quaternion.Euler(0, 0, Random.Range(-180.0f, 180.0f)));
                }
                break;
            case 'S':
                for (int i = 0; i < 20; i++) {
                    spawnPos = new Vector2(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f));
                    Instantiate(sausagePrefab, spawnPos, Quaternion.Euler(0, 0, Random.Range(-180.0f, 180.0f)));
                }
                break;
            case 'G': 
                for (int i = 0; i < 20; i++) {
                    spawnPos = new Vector2(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f));
                    Instantiate(greenPepperPrefab, spawnPos, Quaternion.Euler(0, 0, Random.Range(-180.0f, 180.0f)));
                }
                break;
            case 'O': 
                for (int i = 0; i < 20; i++) {
                    spawnPos = new Vector2(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f));
                    Instantiate(olivePrefab, spawnPos, Quaternion.Euler(0, 0, Random.Range(-180.0f, 180.0f)));
                }
                break;
        }
    }
}

