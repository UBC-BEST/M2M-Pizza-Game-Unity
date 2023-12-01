using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    [SerializeField] private GameObject gameInstructions;
    [SerializeField] private GameEvent startGameLoopEvent;
    
    private void Start()
    {
        GetScreenSize();
        gameInstructions.SetActive(true);
        StartGameLoop();
    }

    // to do: figure out a way to get these values to every object (and how to set positions based on this ratio) 
    private void GetScreenSize()
    {
        Debug.Log(Screen.width);
        Debug.Log(Screen.height);
    }

    private void StartGameLoop()
    {
        startGameLoopEvent.TriggerEvent();
    }
}
