using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OrderScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer orderSpriteRenderer;
    private Vector2 startingPosition = new Vector2(-6, 8);
    private int orderNumber;
    private bool _pizzaSent; 
    
    private void Awake()
    {
		transform.DOMove(startingPosition, 0);
		StartCoroutine(OrderCoroutine());
    }

    private IEnumerator OrderCoroutine()
    {
        orderNumber = GenerateOrder();
        transform.DOMoveY(3, 1);
        yield return new WaitUntil(() => _pizzaSent);
		_pizzaSent = false;
		
        yield return new WaitForSeconds(0.25f);

        transform.DOMoveX(-10, 1);
        yield return null; 
    }

    private void GenerateOrder()
    {
        orderNumber = randomNumberInRange(1, 15);
		
    }

    public void PizzaSent()
    {
        _pizzaSent = true; 
    }
}
