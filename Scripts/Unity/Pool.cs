using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// Represents a Pool
/// </summary>
/// <typeparam name="T">The type of object to store</typeparam>
public class Pool<T> where T : UnityEngine.Object
{
    public List<T> Models = new List<T>();
    public Queue<T> Queue = new Queue<T>();
    public string Name;

    public Pool(string poolName)
    {
        this.Name = poolName;
    }

    /// <summary>
    /// Obtains a new Object from the Pool.
    /// </summary>
    /// <param name="createNew">Indicates that if the pool is empty, the object should be instantiated. True by default</param>
    /// <param name="modelIndex">The index of the model to create. 0 by default</param>
    /// <returns></returns>
    internal T Get(bool createNew = true, int modelIndex = -1)
    {
        if (Queue.Count > 0)
        {
            return Queue.Dequeue();
        }
        else if (createNew)
        {
            return GameObject.Instantiate(Models[modelIndex >= 0 ? modelIndex : 0]) as T;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Adds an object to the pool
    /// </summary>
    /// <param name="pooled"></param>
    internal void Add(T pooled)
    {
        Queue.Enqueue(pooled);
    }
}