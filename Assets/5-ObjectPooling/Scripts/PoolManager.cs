using System.Collections.Generic;
using UnityEngine;

public static class PoolManager
{
    private static Dictionary<string, Queue<IPooledObject>> pools = new Dictionary<string, Queue<IPooledObject>>();
    private static Dictionary<string, Transform> parentObjects = new Dictionary<string, Transform>();

    public static Queue<T> CreatePool<T>(int size, string prefabName) where T : MonoBehaviour, IPooledObject
    {
        if (!parentObjects.TryGetValue(prefabName, out Transform parent))
        {
            GameObject parentObj = new GameObject("POOL - " + prefabName);
            parent = parentObj.transform;
            parentObjects[prefabName] = parent;
        }

        GameObject prefab = Resources.Load<GameObject>(PATHS.POOLED_OBJ_PATH + prefabName);

        if (prefab == null)
        {
            Debug.LogWarning($"Prefab '{prefabName}' not found at path '{PATHS.POOLED_OBJ_PATH + prefabName}'");
            return null;
        }

        if (prefab.GetComponent<T>() == null)
        {
            Debug.LogWarning($"{prefabName} Prefab doesn't have a component that implements {typeof(T)}");
            return null;
        }

        Queue<T> pool = new Queue<T>();

        for (int i = 0; i < size; i++)
        {
            GameObject objCreated = Object.Instantiate(prefab, parent);
            T pooledObject = objCreated.GetComponent<T>();
            if (pooledObject != null)
            {
                pool.Enqueue(pooledObject);
                objCreated.SetActive(false);
            }
        }

        pools[prefabName] = new Queue<IPooledObject>(pool as IEnumerable<IPooledObject>);
        return pool;
    }

    public static T GetPooledObject<T>(string prefabName) where T : MonoBehaviour, IPooledObject
    {
        if(pools.TryGetValue(prefabName, out Queue<IPooledObject> objectPool))
        {
            if (objectPool.Count > 0)
            {
                T pooledObject = objectPool.Dequeue() as T;
                pooledObject.gameObject.SetActive(true);
                pooledObject.OnRetrieved();
                return pooledObject;
            }
            else
            {
                GameObject prefab = Resources.Load<GameObject>(PATHS.POOLED_OBJ_PATH + prefabName);
                if (prefab == null)
                {
                    Debug.LogWarning($"Prefab '{prefabName}' not found at path '{PATHS.POOLED_OBJ_PATH + prefabName}'");
                    return null;
                }
                // Instantiate a new object
                GameObject objCreated = Object.Instantiate(prefab);
                T pooledObject = objCreated.GetComponent<T>();
                if (pooledObject == null)
                {
                    Debug.LogWarning($"{prefabName} Prefab doesn't have a component that implements {typeof(T)}");
                    return null;
                }
                
                if (!parentObjects.TryGetValue(prefabName, out Transform parent))
                {
                    Debug.LogWarning($"Parent object for '{prefabName}' not found.");
                    return null;
                }

                pooledObject.transform.SetParent(parent);
                objectPool.Enqueue(pooledObject);
                pooledObject.gameObject.SetActive(true);
                pooledObject.OnRetrieved();
                return pooledObject;

            }
        }

        return null;
    }

    public static void ReturnPooledObject<T>(string prefabName, T obj) where T : MonoBehaviour, IPooledObject
    {
        obj.gameObject.SetActive(false);
        if (pools.TryGetValue(prefabName, out Queue<IPooledObject> objectPool))
        {
            objectPool.Enqueue(obj);
        }
        obj.OnReturnedPool();
    }
}
