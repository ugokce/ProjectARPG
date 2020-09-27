using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : new()
{
    List<T> pool = new List<T>();

    public T Pull()
    {
        if (pool.Count < 1)
            return new T();

        int lastIndex = pool.Count - 1;
        T pooledObject = pool[lastIndex];
        pool.RemoveAt(lastIndex);

        return pooledObject;
    }

    public void Push(T pooledObject)
    {
        pool.Add(pooledObject);
    }

    public void Push(IList<T> pooledObjects)
    {
        pool.AddRange(pooledObjects);
    }
}