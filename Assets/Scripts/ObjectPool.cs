using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class ObjectPool<T> where T: MonoBehaviour
{
    public T Prefab { get; private set; }
    public Transform Container { get; private set; }

    private List<T> _pool;

    public ObjectPool(T prefab, int count)
    {
        Prefab = prefab;
        Container = null;
        CreatePool(count);
    }

    public ObjectPool(T prefab, int count, Transform container)
    {
        Prefab = prefab;
        Container = container;
        CreatePool(count);
    }

    public T GetFreeElement()
    {
        if (HasFreeElement(out T element))
        {
            return element;
        }

        return CreateObject(true);
    }

    public void PutElement(T element)
    {
        element.gameObject.SetActive(false);
        element.transform.position = Container.position;
        _pool.Add(element);
    }

    public void Reset()
    {
        _pool.Clear();
    }
    
    private bool HasFreeElement(out T element)
    {
        foreach (T obj in _pool)
        {
            if (obj.gameObject.activeInHierarchy == false)
            {
                element = obj;
                obj.gameObject.SetActive(true);
                return true;
            }
        }
        
        element = null;
        return false;
    }

    private void CreatePool(int count)
    {
        _pool = new List<T>();

        for (int i = 0; i < count; i++)
        {
            CreateObject();
        }
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        T createdObject = Object.Instantiate(Prefab, Container, true);
        createdObject.gameObject.SetActive(isActiveByDefault);
        _pool.Add(createdObject);
        return createdObject;
    }
}