using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandlerScript : MonoBehaviour
{
    [SerializeField] private GameEvent indexInput, middleInput, ringInput, pinkyInput;
    private string inputMode;
    private bool inputAllowed;
    
    public void Awake()
    {
        inputAllowed = false;
        inputMode = "keyboard"; 

        // TODO: open serial
        // if serial opens, inputMode = serial;
        // if serial doesn't open, inputMode = keyboard; 
    }

    private void Update()
    {
        if (inputAllowed && inputMode == "serial") SerialInput();
        if (inputAllowed && inputMode == "keyboard") KeyboardInput();
    }

    // need to write this later 
    private void SerialInput()
    {
        
    }

    // add timeout control
    private void KeyboardInput()
    {
		if (Input.GetKeyDown(KeyCode.P)) indexInput.TriggerEvent();
        if (Input.GetKeyDown(KeyCode.S)) middleInput.TriggerEvent();
        if (Input.GetKeyDown(KeyCode.G)) ringInput.TriggerEvent();
        if (Input.GetKeyDown(KeyCode.O)) pinkyInput.TriggerEvent();
    }

    public void StartInputStreaming()
    {
        inputAllowed = true;
    }

    public void StopInputStreaming()
    {
        inputAllowed = false;
    }
}
