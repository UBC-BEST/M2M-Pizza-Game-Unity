using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class InputHandlerScript : MonoBehaviour
{
    [SerializeField] private GameEvent indexInput, middleInput, ringInput, pinkyInput;
    private string inputMode;
    private bool inputAllowed;
    SerialPort stream = new SerialPort("\\\\.\\COM5", 115200);
    string[] fingerValueStrings = {"", "", "", ""};
    int[] fingerValues = {0, 0, 0, 0};
    int inputTimeout = 0;
    
    public void OnEnable()
    {
        inputAllowed = false;
        stream.Open();
        inputMode = "serial";
        // inputMode = "keyboard"; 
    }

    private void Update()
    {
        if (inputAllowed && inputMode == "serial") SerialInput();
        if (inputAllowed && inputMode == "keyboard") KeyboardInput();
    }

    private void SerialInput()
    {     
        // edit to match output 
        fingerValueStrings = stream.ReadLine().Split(", "); 

        for (int i = 0; i < 4; i++) {
            fingerValues[i] = int.Parse(fingerValueStrings[i]);
        }

        InputControl();
    }

    void InputControl() {
        if (fingerValues[0] > 30 && inputTimeout == 0) {
            indexInput.TriggerEvent();
            inputTimeout = 10; 
        }
        if (fingerValues[1] > 30 && inputTimeout == 0) {
            middleInput.TriggerEvent();
            inputTimeout = 10; 
        }
        if (fingerValues[2] > 30 && inputTimeout == 0) {
            ringInput.TriggerEvent();
            inputTimeout = 10; 
        }
        if (fingerValues[3] > 30 && inputTimeout == 0) {
            pinkyInput.TriggerEvent(); 
            inputTimeout = 10; 
        }

        // TODO: arbitrary timeout - do later 
        if (inputTimeout > 0) inputTimeout = inputTimeout - 1;
    }

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