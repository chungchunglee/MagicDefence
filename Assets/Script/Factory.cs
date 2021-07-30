using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory
{
    readonly List<RecycleObject> _pool = new List<RecycleObject>();
    private readonly int _defaultPoolSize;
    readonly RecycleObject _prefab;

    public Factory(RecycleObject prefab, int defaultPoolSize = 5)
    {
        this._prefab = prefab;
        this._defaultPoolSize = defaultPoolSize;

        Debug.Assert(this._prefab != null, "Prefab is null!");
    }

    private void CreatePool()
    {
        for (var i = 0; i < _defaultPoolSize; i++)
        {
            var obj = Object.Instantiate(_prefab) as RecycleObject;
            obj.gameObject.SetActive(false);
            _pool.Add(obj);
        }
    }

    public RecycleObject Get()
    {
        if (_pool.Count == 0)
        {
            CreatePool();
        }

        var lastIndex = _pool.Count - 1;
        var obj = _pool[lastIndex];
        _pool.RemoveAt(lastIndex);
        obj.gameObject.SetActive(true);
        return obj;
    }

    public void Restore(RecycleObject obj)
    {
        Debug.Assert(obj != null, "Null object to be returned!");
        if (obj is null) return;
        obj.gameObject.SetActive(false);
        _pool.Add(obj);
    }
}