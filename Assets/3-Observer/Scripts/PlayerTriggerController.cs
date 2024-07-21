using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerController : MonoBehaviour
{
    GameManagerObserver gameManagerObserver;
    private void Awake()
    {
        gameManagerObserver = FindObjectOfType<GameManagerObserver>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Coin _coin))
        {
            if (gameManagerObserver != null)
                gameManagerObserver.IncreaseCoinCollected(1);
            
            Destroy(_coin.gameObject);
        }
    }
}
