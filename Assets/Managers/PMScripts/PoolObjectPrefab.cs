using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjectPrefab : MonoBehaviour, IPoolable
{
    [SerializeField]
    private Rigidbody _rigidbody;

    public void Active()
    {

    }

    public void Create()
    {

    }

    public void Deactive()
    {
        
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

}
