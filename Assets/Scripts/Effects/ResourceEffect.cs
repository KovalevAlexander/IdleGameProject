using System.Collections.Generic;

using UnityEngine;

public abstract class ResourceEffect : Effect
{
    [SerializeField] protected bool perSecond;
    [SerializeField] protected ResourceDictionary affectedResources;

    protected ResourceDictionary m_Resources;

    private void Awake()
    {
        m_Resources = affectedResources;
    }

    public float this[ResourceType type] => m_Resources[type];

    protected ICollection<ResourceType> GetResourceTypes() => m_Resources.Keys;

    protected ResourceDictionary ScaleEffectPerSecond(ResourceDictionary dictionary)
    {
        if (perSecond)
        {
            var scaledDictionary = dictionary.Scale(Time.deltaTime);
            return scaledDictionary;
        }
        return m_Resources;
    }
}
