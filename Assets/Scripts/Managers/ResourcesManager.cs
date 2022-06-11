using System;
using System.Linq;

using UnityEngine;

using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine.Events;

public sealed class ResourcesManager : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private ResourcesDictionary Resources = new();
    [Header("UI")]
    [SerializeField] private GameObject uiPrefab;
    [SerializeField] private Transform uiRoot;

    public Action onResourcesUpdate;
    public bool ResourceHasMoreOrEqual(ResourceType type, float value)
    => GetResource(type).Value >= value;

    public bool ResourceFilled(ResourceType type)
        => GetResource(type).isFull;

    private readonly Representer<Resource, ResourceRepresentation> m_Representer = new();

    private void Start()
    {
        m_Representer.CreateRepresentations(Resources.Values.ToArray(), uiPrefab, uiRoot);
    }

    public void IncreaseResource(ResourceType type, float value)
    {
        GetResource(type).Add(value);
        onResourcesUpdate?.Invoke();
    }

    public void DecreseResource(ResourceType type, float value)
    {
        GetResource(type).Substract(value);
        onResourcesUpdate?.Invoke();
    }

    private Resource GetResource(ResourceType type) 
        => Resources[type];
}