using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryGameManager : MonoBehaviour
{
    CoffeeFactory<Americano> americanoFactory;
    CoffeeFactory<Latte> latteFactory;
    private void Start()
    {
        americanoFactory = new CoffeeFactory<Americano>("AmericanoPrefab");
        latteFactory = new CoffeeFactory<Latte>("LattePrefab");

        ICoffee americano = americanoFactory.CreateCoffee();
        if(americano != null)
            americano.Prepare();

        ICoffee latte = latteFactory.CreateCoffee(new Vector3(2,-0.1f,2));
        if (latte != null)
            latte.Prepare();

        Debug.Log(string.Format("Produced Americano Number: {0}", americanoFactory.GetCoffeesCreated().Count));
        Debug.Log(string.Format("Produced Latte Number: {0}", latteFactory.GetCoffeesCreated().Count));

    }

}
