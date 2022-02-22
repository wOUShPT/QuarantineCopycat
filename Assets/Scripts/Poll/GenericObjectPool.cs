using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericObjectPool<T> : MonoBehaviour where T : Component
{
    [SerializeField] private T[] prefab;

    public static GenericObjectPool<T> Instance { get; private set; }
    private Queue<T> objects = new Queue<T>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            //The instance is not this one
            Destroy(Instance.gameObject);
        }
        Instance = this;
    }

    public T Get()
    {
        if(objects.Count == 0)
        {
            //Pool is empty
            AddObject();
        }
        return objects.Dequeue();
    }

    public void ReturnToPool(T objectToReturn)
    {
        objectToReturn.gameObject.SetActive(false);
        objects.Enqueue(objectToReturn);
    }
    private void AddObject()
    {
        var newObject = GameObject.Instantiate(prefab[Random.Range(0, prefab.Length)]);
        newObject.gameObject.SetActive(false);
        objects.Enqueue(newObject);
    }
}
