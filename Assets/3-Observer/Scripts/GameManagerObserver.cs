using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManagerObserver : MonoBehaviour
{
    int coinCollected = 0;

    public void IncreaseCoinCollected(int _amount)
    {
        coinCollected+= _amount;
        Debug.Log("Coin Collected!");
        Coin.OnCollected?.Invoke(coinCollected);
    }

}
