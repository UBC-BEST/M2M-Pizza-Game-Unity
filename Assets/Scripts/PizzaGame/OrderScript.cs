using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OrderScript : MonoBehaviour
{
	[SerializeField] private GameObject pepperoniPrefab, sausagePrefab, greenPepperPrefab, olivePrefab;
	[SerializeField] private SpriteRenderer orderSpriteRenderer;
    [SerializeField] private GameEvent pizzaSent;
    private Vector2 startingPosition = new Vector2(-6, 8);
    private bool _pizzaSent = false;
	private Order currentOrder;
    
    private void OnEnable()
    {
		transform.DOMove(startingPosition, 0);
		StartCoroutine(OrderCoroutine());
    }

    private IEnumerator OrderCoroutine()
    {
	    currentOrder = new Order();
	    
	    transform.DOMoveY(3, 1);
        yield return new WaitUntil(() => _pizzaSent);
		_pizzaSent = false;
		
        yield return new WaitForSeconds(0.25f);

        transform.DOMoveX(-10, 1);
        yield return null; 
    }
    
    public void AddPepperoni()
    {
	    if (currentOrder.pepperoniComplete) return;
	    currentOrder.pepperoni++;
	    if (currentOrder.pepperoni == currentOrder.pepperoniNeeded) currentOrder.pepperoniComplete = true;

	    CheckIfPizzaDone();
    }

    public void AddSausage()
    {
	    if (currentOrder.sausageComplete) return;
	    currentOrder.sausage++;
	    if (currentOrder.sausage == currentOrder.sausageNeeded) currentOrder.sausageComplete = true;
	    
	    CheckIfPizzaDone();
    }

    public void AddGreenPepper()
    {
	    if (currentOrder.greenPepperComplete) return;
	    currentOrder.greenPepper++;
	    if (currentOrder.greenPepper == currentOrder.greenPepperNeeded) currentOrder.greenPepperComplete = true;
	    
	    CheckIfPizzaDone();
    }

    public void AddOlive()
    {
	    if (currentOrder.oliveComplete) return;
	    currentOrder.olive++;
	    if (currentOrder.olive == currentOrder.oliveNeeded) currentOrder.oliveComplete = true;
	    
	    CheckIfPizzaDone();
    }

    private void CheckIfPizzaDone()
    {
		if (currentOrder.pepperoniComplete &&
	        currentOrder.sausageComplete &&
	        currentOrder.greenPepperComplete &&
	        currentOrder.oliveComplete)
	    {
		    pizzaSent.TriggerEvent();
		    _pizzaSent = true;
	    }
    }

	private class Order
	{
		public int pepperoni, sausage, greenPepper, olive = 0;
		public int pepperoniNeeded, sausageNeeded, greenPepperNeeded, oliveNeeded;
		public bool orderComplete, pepperoniComplete, sausageComplete, greenPepperComplete, oliveComplete = false; 

		public Order()
		{
			pepperoniNeeded = Random.Range(0, 4);
			sausageNeeded = Random.Range(0, 4);
			greenPepperNeeded = Random.Range(0, 4);
			oliveNeeded = Random.Range(0, 4);

			Debug.Log("P: " + pepperoniNeeded + "   S: " + sausageNeeded + "   G: " + greenPepperNeeded + "   O: " + oliveNeeded);

			if (pepperoniNeeded == 0) pepperoniComplete = true;
			if (sausageNeeded == 0) sausageComplete = true;
			if (greenPepperNeeded == 0) greenPepperComplete = true;
			if (oliveNeeded == 0) oliveComplete = true;
			
			// TODO: foreach in range needed; spawn the topping onto the ticket 
		}
	}
}
