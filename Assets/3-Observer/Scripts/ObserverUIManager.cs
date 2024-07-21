using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObserverUIManager : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI coinCollectedText;
    [SerializeField] private GameObject overScreen;
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
        coinCollectedText.text = string.Format("Coin Collected: {0}", _coinCollected);
    }

    public void OnObjectiveReachedSizeLimit(Objective _objective)
    {
        if(overScreen != null)
            overScreen.gameObject.SetActive(true);
    }

}
