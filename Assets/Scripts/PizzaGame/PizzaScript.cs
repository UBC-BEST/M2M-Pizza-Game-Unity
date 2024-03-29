using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PizzaScript : MonoBehaviour
{
    [SerializeField] private GameEvent pizzaAtMiddle, pizzaOffScreen;
    private Vector2 startPosition = new Vector2(-12, -1.2f);
    private bool _pizzaSent;
    
    private void OnEnable()
    {
        transform.DOMove(startPosition, 0);   
		StartCoroutine(PizzaCoroutine());

    }

    private IEnumerator PizzaCoroutine()
    {
        transform.DOMoveX(1.6f, 2).SetEase(Ease.InOutSine);
        transform.DOMoveY(-1.2f, 2).SetEase(Ease.InOutSine);
        transform.DORotate(new Vector3(0, 0, 360), 2, RotateMode.FastBeyond360)
            .SetEase(Ease.InOutSine);
        yield return new WaitForSeconds(2);

        pizzaAtMiddle.TriggerEvent();
        yield return new WaitUntil(() => _pizzaSent); 
		_pizzaSent = false;

        transform.DOMoveX(12, 2).SetEase(Ease.InSine);
        transform.DORotate(new Vector3(0, 0, 360), 2, RotateMode.FastBeyond360)
            .SetEase(Ease.InSine);
        yield return new WaitForSeconds(2);
        
        pizzaOffScreen.TriggerEvent();
        yield return null; 
    }

    public void PizzaSent()
    {
        _pizzaSent = true; 
    }
}
