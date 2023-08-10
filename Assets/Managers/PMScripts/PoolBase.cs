using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolBase : MonoBehaviour
{
    private void Awake()
    {
        PoolManager.Instance.Register(GetType().Name, this);
    }

    public abstract void Initialize();

    protected GameObject _activeParent;
    protected GameObject _deactiveParent;
}
