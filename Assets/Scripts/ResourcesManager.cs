using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RotaryHeart.Lib.SerializableDictionary;
public class ResourcesManager : Singleton<ResourcesManager>
{
    public Transform ResourcesRepresentationRoot;

    [SerializeField] private ResourcesDictionary Resources = new();

    public Resource GetResource(ResourceType type)
    {
        return Resources[type];
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