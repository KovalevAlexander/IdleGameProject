using System;
using System.Linq;

using UnityEngine;

using RotaryHeart.Lib.SerializableDictionary;

public sealed class ResourcesManager : Singleton<ResourcesManager>
{
    [Header("General")]
    [SerializeField] private ResourcesDictionary Resources = new();

    [Header("UI")]
    [SerializeField] private GameObject uiPrefab;
    [SerializeField] private Transform uiRoot;

    public Action onResourcesUpdated;

    private readonly ResourceRepresenter m_Representer = new();

    private void Start()
    {
        m_Representer.CreateRepresentations(Resources.Values.ToArray(), uiPrefab, uiRoot);
    }

    private Resource GetResource(ResourceType type) => Resources[type];

    public bool ResourceHasMoreOrEqual(ResourceType type, float value) => GetResource(type).Value >= value;

    public bool ResourceFilled(ResourceType type) => Resources[type].isFull;


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

}

[System.Serializable]
public class ResourcesDictionary : SerializableDictionaryBase<ResourceType, Resource> { }