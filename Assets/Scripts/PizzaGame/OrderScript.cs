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
	private List<GameObject> allToppings = new List<GameObject>();
    

    private void OnEnable()
    {
		transform.DOMove(startingPosition, 0);
		StartCoroutine(OrderCoroutine());
    }

    private IEnumerator OrderCoroutine()
    {
	    currentOrder = new Order();

		AddOliveOnTicket();
		AddPepperoniOnTicket();
		AddSausageOnTicket();
		AddGreenPepperOnTicket();
	    
	    transform.DOMoveY(2, 1);
        yield return new WaitUntil(() => _pizzaSent);
		_pizzaSent = false;
		
        yield return new WaitForSeconds(0.25f);

        transform.DOMoveX(-10, 1);
		MoveAllToppings();
        yield return null; 
    }

	private void MoveAllToppings() {
    	foreach (GameObject topping in allToppings) {
        	        topping.transform.DOMoveX(-10, 1).OnComplete(() => {
            // Fade out the topping after it has finished moving
            topping.GetComponent<SpriteRenderer>().DOFade(0, 0.5f).OnComplete(() => {
                // Optionally, destroy the topping object after fading out
            });
        });
    	}
	}

	public void AddPepperoniOnTicket() {
		int pepperoniNeeded = currentOrder.GetPepperoniNeeded();
		GameObject[] pepperoniObjects = new GameObject[pepperoniNeeded];

		for (int i = 0; i < pepperoniNeeded; i++) {
			pepperoniObjects[i] = Instantiate(pepperoniPrefab, new Vector3(-7f + i, 8f, 0), Quaternion.identity);
			allToppings.Add(pepperoniObjects[i]);
		}

		for (int i = 0; i< pepperoniNeeded; i++) {
			pepperoniObjects[i].transform.DOMove(new Vector3(-7.1f + i, 2.35f), 1.0f);
			pepperoniObjects[i].GetComponent<SpriteRenderer>().sortingOrder = orderSpriteRenderer.sortingOrder + 3;
		}
	}

	public void AddSausageOnTicket() {
		int sausageNeeded = currentOrder.GetSausageNeeded();
		GameObject[] sausageObjects = new GameObject[sausageNeeded];

		for (int i = 0; i < sausageNeeded; i++) {
			sausageObjects[i] = Instantiate(sausagePrefab, new Vector3(-7.07f + i, 8f, 0), Quaternion.identity);
			allToppings.Add(sausageObjects[i]);
		}

		for (int i = 0; i< sausageNeeded; i++) {
			sausageObjects[i].transform.DOMove(new Vector3(-7.07f + i, 1.59f), 1.0f);
			sausageObjects[i].GetComponent<SpriteRenderer>().sortingOrder = orderSpriteRenderer.sortingOrder + 3;
		}
	}

	public void AddGreenPepperOnTicket() {
		int greenPepperNeeded = currentOrder.GetGreenPepperNeeded();
		GameObject[] greenPepperObjects = new GameObject[greenPepperNeeded];

		for (int i = 0; i < greenPepperNeeded; i++) {
			greenPepperObjects[i] = Instantiate(greenPepperPrefab, new Vector3(-7f + i, 8f, 0), Quaternion.identity);
			allToppings.Add(greenPepperObjects[i]);
		}

		for (int i = 0; i< greenPepperNeeded; i++) {
			greenPepperObjects[i].transform.DOMove(new Vector3(-7f + i, 0.79f), 1.0f);
			greenPepperObjects[i].GetComponent<SpriteRenderer>().sortingOrder = orderSpriteRenderer.sortingOrder + 3;
		}
	}

	public void AddOliveOnTicket() {
		int oliveNeeded = currentOrder.GetOliveNeeded();
		GameObject[] oliveObjects = new GameObject[oliveNeeded];

		for (int i = 0; i < oliveNeeded; i++) {
    		oliveObjects[i] = Instantiate(olivePrefab, new Vector3(-7f + i, 8f, 0), Quaternion.identity);
			allToppings.Add(oliveObjects[i]);
		}

		for (int i = 0; i < oliveNeeded; i++) {
    		oliveObjects[i].transform.DOMove(new Vector3(-7f + i, 3.2f), 1.0f);
    		oliveObjects[i].GetComponent<SpriteRenderer>().sortingOrder = orderSpriteRenderer.sortingOrder + 2;
		}
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
		public int pepperoni, sausage, greenPepper, olive;
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

			// if (pepperoniNeeded == 1)  
			Debug.Log(Screen.width);
			Debug.Log(Screen.height);
			
			
		}

		public int GetPepperoniNeeded(){
        		return pepperoniNeeded;
    		}

    		public int GetSausageNeeded(){
        		return sausageNeeded;
    		}

    		public int GetGreenPepperNeeded(){
        		return greenPepperNeeded;
    		}

    		public int GetOliveNeeded(){
        		return oliveNeeded;
    		}

	}
}
