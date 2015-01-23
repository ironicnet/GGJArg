using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Handles and holds several pools
/// </summary>
public static class PoolsManager
{
    static Dictionary<string, Pool<GameObject>> pools = new Dictionary<string, Pool<GameObject>>();

    /// <summary>
    /// Put the <paramref name="pooled"/> object into the pool matching the <paramref name="poolname"/>
    /// </summary>
    /// <param name="poolName">The pool where to put the object</param>
    /// <param name="pooled">The object to store</param>
    public static void PutInPool(string poolName, GameObject pooled)
    {
        if (!pools.ContainsKey(poolName))
        {
            pools.Add(poolName, new Pool<GameObject>(poolName));
        }
        if (pooled != null)
        {
            pooled.SetActive(false);
            pools[poolName].Add(pooled);
        }
    }
    /// <summary>
    /// Obtains an object from the pool. 
    /// </summary>
    /// <param name="poolName">The pool from where to obtain the object</param>
    /// <param name="createNew">Indicates that if the pool is empty a new instance must be created. True by default</param>
    /// <param name="modelIndex">The index oft the model to instantiate</param>
    /// <returns></returns>
    public static GameObject GetFromPool(string poolName, bool createNew = true, int modelIndex = -1)
    {
        Pool<GameObject> pool = pools[poolName];
        return pool.Get(createNew, modelIndex);
    }
    /// <summary>
    /// Adds a pool to the manager
    /// </summary>
    /// <param name="pool">The pool to store</param>
    public static void AddPool(Pool<GameObject> pool)
    {
        pools.Add(pool.Name, pool);
    }
    /// <summary>
    /// Removes a pool from the manager
    /// </summary>
    /// <param name="pool">The pool object to remove</param>
    public static void RemovePool(Pool<GameObject> pool)
    {
        pools.Remove(pool.Name);
    }
    /// <summary>
    /// Removes a pool from the manager
    /// </summary>
    /// <param name="poolName">The name of the pool to remove</param>
    public static void RemovePool(string poolName)
    {
        pools.Remove(poolName);
    }
}