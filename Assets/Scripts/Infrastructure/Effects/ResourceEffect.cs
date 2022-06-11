using System.Collections.Generic;

using UnityEngine;

public abstract class ResourceEffect : Effect
{
    [SerializeField] protected bool perSecond;
    [SerializeField] protected ResourceDictionary affectedResources;

    public float this[ResourceType type] => affectedResources[type];

    protected ICollection<ResourceType> GetResourceTypes() => affectedResources.Keys;

    protected ResourceDictionary ScaleEffectPerSecond(ResourceDictionary dictionary)
    {
        if (perSecond)
        {
            var scaledDictionary = dictionary.Scale(Time.deltaTime);
            return scaledDictionary;
        }
        return affectedResources;
    }
}
