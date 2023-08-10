using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[DefaultExecutionOrder(-100_100)]
public abstract class JSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance;
    public abstract IEnumerator Initialize();
    public virtual void Awake()
    {
        Instance = FindObjectOfType<T>();
    }
}
