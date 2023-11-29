using System.Collections;
using System.IO.Ports;
using UnityEngine;

public class FSRHandlerScript : MonoBehaviour
{
    [SerializeField] GameEvent indexPressed, middlePressed, ringPressed, pinkyPressed; 
    SerialPort stream = new SerialPort("\\\\.\\COM5", 9600);
    string[] fingerValueStrings = {"", "", "", ""}; 
    int[] fingerValues = {0, 0, 0, 0};
    int inputTimeout = 0; 
    
    // Start is called before the first frame update
    void Start()
    {
        stream.Open();
    }

    // Update is called once per frame
    void Update()
    {
        fingerValueStrings = stream.ReadLine().Split(", "); 

        for (int i = 0; i < 4; i++) {
            fingerValues[i] = int.Parse(fingerValueStrings[i]);
        }

        InputControl();
    }

    void InputControl() {
        if (fingerValues[0] > 100 && inputTimeout == 0) {
            indexPressed.TriggerEvent();
            inputTimeout = 10; 
        }
        if (fingerValues[1] > 100 && inputTimeout == 0) {
            middlePressed.TriggerEvent();
            inputTimeout = 10; 
        }
        if (fingerValues[2] > 100 && inputTimeout == 0) {
            ringPressed.TriggerEvent();
            inputTimeout = 10; 
        }
        if (fingerValues[3] > 100 && inputTimeout == 0) {
            pinkyPressed.TriggerEvent(); 
            inputTimeout = 10; 
        }

        if (inputTimeout > 0) inputTimeout = inputTimeout - 1;
    }
}
