using System.Collections;
using UnityEngine;

public class Latte : MonoBehaviour, ICoffee
{
    public string GetName()
    {
        return "Latte";
    }

    public void Prepare()
    {
        Debug.Log("Latte is prepared!");
    }

}
