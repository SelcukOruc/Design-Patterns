using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Objective : MonoBehaviour
{
    [SerializeField] private GameManagerObserver gameManagerObserver;
    [SerializeField] private UnityEvent<Objective> OnReachedSizeLimit;
    private void OnEnable()
    {
        Coin.OnCollected += OnCoinCollected;
    }
    private void OnDisable()
    {
        Coin.OnCollected -= OnCoinCollected;
    }

    void OnCoinCollected(int _coinCollected)
    {
        transform.localScale *= _coinCollected;  
        
        if(transform.localScale.x >= 3)
            OnReachedSizeLimit?.Invoke(this);

    }

}
