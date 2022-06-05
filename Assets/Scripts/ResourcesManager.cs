using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RotaryHeart.Lib.SerializableDictionary;
using System;

public class ResourcesManager : Singleton<ResourcesManager>
{
    public Transform ResourcesRepresentationRoot;

    public Action onResourcesUpdated;

    [SerializeField] private ResourcesDictionary Resources = new();

    public Resource GetResource(ResourceType type)
    {
        return Resources[type];
    }

    public void IncreaseResource(ResourceType type, float value)
    {
        GetResource(type).Add(value);
        onResourcesUpdated?.Invoke();
    }

    public void DecreseResource(ResourceType type, float value)
    {
        GetResource(type).Substract(value);
        onResourcesUpdated?.Invoke();
    }

    private void Start()
    {
        foreach (var key in Resources.Keys)
        {
            Resources[key].Initialize();
        }
    }
}

[System.Serializable]
public class ResourcesDictionary : SerializableDictionaryBase<ResourceType, Resource> {}