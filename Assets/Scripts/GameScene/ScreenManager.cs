/*
    Screen manager. For now, all it's doing is ensuring the phone is in landscape mode. 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
}
