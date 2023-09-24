using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to manage screen settings. <br/>
/// Currently, all it does is ensure the mobile device is in landscape mode. 
/// </summary>
public class ScreenManager : MonoBehaviour
{
    /// <summary>
    /// Set the screen orientation of the mobile device to landscape. 
    /// </summary>
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
}
