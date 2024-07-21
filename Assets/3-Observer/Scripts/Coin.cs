using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public delegate void OnInteraction(int _coinAmount);
    public static OnInteraction OnCollected;

   
}
