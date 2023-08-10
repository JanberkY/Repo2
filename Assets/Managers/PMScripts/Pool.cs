using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System.Linq;

public class Pool<T> : PoolBase where T : IPoolable
{
    protected const string ACTIVE_NAME = "Active";
    protected const string DEACTIVE_NAME = "Deactive";

    [SerializeField, HorizontalLine(1, EColor.Orange)]
    private T _prefab;

    [SerializeField, HorizontalLine(1, EColor.Orange), Range(0, 10000000)]
    private int _intCount;

    [SerializeField, HorizontalLine(1, EColor.Orange)]
    protected bool _checkoverrideParent = false;

    private List<T> _activeList;
    private List<T> _deactiveList;

    public override void Initialize()
    {
        if (!_checkoverrideParent)
            CreateParent();

        _activeList = new List<T>();
        _deactiveList = new List<T>();

        for (int i = 0; i < _intCount; i++)
        {
            var data = CreatePoolPrefab();
            Push(data);
        }
    }
    private void CreateParent()
    {
        CreateParent(ref _activeParent, ACTIVE_NAME);
        CreateParent(ref _deactiveParent, DEACTIVE_NAME);
    }
    protected void CreateParent(ref GameObject obj, string name)
    {
        if (obj == null)
        {
            obj = new GameObject(name);
            obj.transform.SetParent(transform);
        }
    }
    private T CreatePoolPrefab()
    {
        var obj = (object)_prefab;
        var o = (Object)obj;
        var inst = Instantiate(o, _deactiveParent.transform) as IPoolable;

        T data = (T)inst;
        HandleCreatablePrefab(data);

        return data;
    }
    private void HandleCreatablePrefab(T inst)
    {
        inst.Create();
        inst.GetGameObject().SetActive(false);
    }

    private void Push(T item)
    {
        _deactiveList.Add(item);
        item.Deactive();
        item.GetGameObject().SetActive(false);
        item.GetGameObject().transform.SetParent(_deactiveParent.transform);
    }

    private T Pop()
    {
        int count = _deactiveList.Count;

        if (count > 0)
        {
            var d = _deactiveList.First();
            _deactiveList.Remove(d);

            GotoActiveList(d);
            return d;
        }
        else
        {
            var d = CreatePoolPrefab();
            GotoActiveList(d);

            return d;
        }
    }

    private void GotoActiveList(T d)
    {
        d.GetGameObject().SetActive(true);
        d.Active();
        d.GetGameObject().transform.SetParent(_activeParent.transform);

        _activeList.Add(d);
    }

    public virtual T GetFromPool()
    {
        var item = Pop();
        return item;
    }

    public virtual void MoveToPool(T data)
    {
        _activeList.Remove(data);
        Push(data);
    }

    public void Clear()
    {
        foreach (var item in _activeList)
            Push(item);

        _activeList = new List<T>();
    }
    public List<T> GetActiveList()
    {
        return _activeList;
    }

}
