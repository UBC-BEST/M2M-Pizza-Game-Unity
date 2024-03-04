using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 

public class ToppingScript : MonoBehaviour
{
    public void Movement()
    {
        transform.DOMoveX(12, 2).SetEase(Ease.InSine);
        
        transform.DORotate(new Vector3(0, 0, 360), 2, RotateMode.FastBeyond360)
            .SetEase(Ease.InSine);
        // instead of the above function, rotate the topping by 360 degrees regardless of initial position 
        // you'll need to look at the DOTween library documentation to see if there's anything that allows this 
        // don't worry if the pizza looks weird after; we can update the pizza rotation function after 
    }
}
