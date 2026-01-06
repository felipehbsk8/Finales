using System;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
    T _prefab;
    int _initialCount = 0;
    Queue<T> _pool = new Queue<T>();

    Func<T, T> _buildOptions = null;

    public void Initalize(T prefab, int initialCount, Func<T, T> buildOp = null)
    {
        _prefab = prefab;
        _initialCount = initialCount;
        _buildOptions = buildOp;
        Create();
    }

    private void Create()
    {
        for (int i = 0; i < _initialCount; i++)
        {
            var obj = GameObject.Instantiate(_prefab);
            obj.gameObject.SetActive(false);
            _pool.Enqueue(obj);
        }
    }

    public T GetObject()
    {
        if (_pool.Count > 0)
        {
            var obj = _pool.Dequeue();
            obj.gameObject.SetActive(true);
            if (_buildOptions != null)
                obj = _buildOptions.Invoke(obj);
            return obj;
        }
        else
        {
            Create();
            var obj = _pool.Dequeue();
            obj.gameObject.SetActive(true);
            if (_buildOptions != null) obj = _buildOptions.Invoke(obj);
            return obj;
        }
    }

    public void ReturnToPool(T obj)
    {
        obj.gameObject.SetActive(false);
        _pool.Enqueue(obj);
    }
}
