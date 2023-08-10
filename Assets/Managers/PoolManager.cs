using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : JSingleton<PoolManager>
{
    private Dictionary<string, PoolBase> _pools = new Dictionary<string, PoolBase>();
    public override IEnumerator Initialize()
    {
        yield return null;

        foreach (var item in _pools)
        {
            item.Value.Initialize();
        }
    }

    public void Register(string key, PoolBase s)
    {
        _pools.Add(key, s);
    }
    public PoolBase GetPool(string key)
    {
        return _pools[key];
    }
}
