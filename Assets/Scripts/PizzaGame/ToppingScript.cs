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
    }
}
