using System.Collections;
using System.IO.Ports;
using UnityEngine;

public class FSRHandlerScript : MonoBehaviour
{
    SerialPort stream = new SerialPort("\\\\.\\COM5", 9600);
    string streamValue; 
    
    // Start is called before the first frame update
    void Start()
    {
        stream.Open();
    }

    // Update is called once per frame
    void Update()
    {
        streamValue = stream.ReadLine();
        Debug.Log(streamValue);
    }
}
