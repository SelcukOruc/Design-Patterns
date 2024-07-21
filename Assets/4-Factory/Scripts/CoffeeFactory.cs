
using UnityEditor;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
public class CoffeeFactory<T> where T : MonoBehaviour, ICoffee
{
    private string _prefabPath;
    List<ICoffee> coffeesCreated;
    public CoffeeFactory(string _prefabName)
    {
        _prefabPath =  Path.Combine(PATHS.COFFE_PATH, _prefabName);
        coffeesCreated = new List<ICoffee>();
    }

    public ICoffee CreateCoffee()
    {
        GameObject prefab = Resources.Load<GameObject>(_prefabPath);

        if (prefab == null)
        {
            Debug.LogError($"Prefab at path {_prefabPath} not found.");
            return null;
        }

        string className = typeof(T).Name;

        GameObject coffeeObject = Object.Instantiate(prefab);
        coffeeObject.name = className;
        
        T coffee = coffeeObject.GetComponent<T>();
        if(coffee == null)
            coffee = coffeeObject.AddComponent<T>();
 
        Debug.Log(className + " Is Created!");
        coffeesCreated.Add(coffee);
        return coffee;
    }

    public ICoffee CreateCoffee(Vector3 _position)
    {
        GameObject prefab = Resources.Load<GameObject>(_prefabPath);

        if (prefab == null)
        {
            Debug.LogError($"Prefab at path {_prefabPath} not found.");
            return null;
        }

        string className = typeof(T).Name;

        GameObject coffeeObject = Object.Instantiate(prefab);
        coffeeObject.name = className;
        coffeeObject.transform.position = _position;

        T coffee = coffeeObject.GetComponent<T>();
        if (coffee == null)
            coffee = coffeeObject.AddComponent<T>();

        Debug.Log(className + " Is Created!");
        coffeesCreated.Add(coffee);
        return coffee;
    }

    public List<ICoffee> GetCoffeesCreated()
    {
        return coffeesCreated;
    }

}
