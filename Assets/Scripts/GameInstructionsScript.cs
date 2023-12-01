using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameInstructionsScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    private Vector2 _startingPosition;
    
    private void Awake()
    {
        _startingPosition = new Vector2(0, 3);
        transform.DOMove(_startingPosition, 0);
    }
}
