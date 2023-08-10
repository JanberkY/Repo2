using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable
{
    void Create();
    void Active();
    void Deactive();
    GameObject GetGameObject();
}
