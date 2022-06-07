using System;
using System.Linq;
using System.Collections.Generic;

using UnityEngine;

using RotaryHeart.Lib.SerializableDictionary;
public sealed class ResourcesManager : Representer<Resource>
{
    [Header("General")]
    [SerializeField] private ResourcesDictionary Resources = new();

    public Action onResourcesUpdated;

    private void Start()
    {
        CreateRepresentations();
    }

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

    protected override void CreateRepresentations()
    {
        var representables = Resources.Values.ToList<IRepresentable>();

        foreach (var representable in representables)
        {
            var representation = RepresentationFactory<ResourceRepresentation>.Get(representable, UIPrefab, UIRoot, colorData);
            m_Representations.Add(representation);
        }
    }
}

[System.Serializable]
public class ResourcesDictionary : SerializableDictionaryBase<ResourceType, Resource> { }