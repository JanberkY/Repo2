using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Pool<PoolObjectPrefab>
{
    [SerializeField]
    private GameObject _overrideActiveParent;

    [SerializeField]
    private GameObject _overrideDeactiveParent;
    public override void Initialize()
    {
        _activeParent = _overrideActiveParent;
        _deactiveParent = _overrideDeactiveParent;
        transform.position = Vector3.zero;
        base.Initialize();
    }

    public override PoolObjectPrefab GetFromPool()
    {
        return base.GetFromPool();
    }
    public override void MoveToPool(PoolObjectPrefab data)
    {
        base.MoveToPool(data);
    }
}
