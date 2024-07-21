using System.Collections;
using UnityEngine;



public class Americano : MonoBehaviour, ICoffee
{
    public string GetName()
    {
        return "Americano";
    }

    public void Prepare()
    {
        Debug.Log("Americano is prepared!");
    }

}
