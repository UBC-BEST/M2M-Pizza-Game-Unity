using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OrderScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer orderSpriteRenderer;
    private Vector2 startingPosition;
    private int orderNumber;
    private bool _pizzaSent; 
    
    private void Awake()
    {
        StartCoroutine(OrderCoroutine());
    }

    private IEnumerator OrderCoroutine()
    {
        _pizzaSent = false;
        
        startingPosition = new Vector2(-6, 8);
        transform.DOMove(startingPosition, 0);
        yield return null;

        orderNumber = GenerateOrder();
        transform.DOMoveY(3, 1);
        yield return new WaitUntil(() => _pizzaSent);
        yield return new WaitForSeconds(0.25f);

        transform.DOMoveX(-10, 1);
        yield return null; 
    }

    // todo - do this 
    private int GenerateOrder()
    {
        return 0;
    }

    public void PizzaSent()
    {
        _pizzaSent = true; 
    }
}
