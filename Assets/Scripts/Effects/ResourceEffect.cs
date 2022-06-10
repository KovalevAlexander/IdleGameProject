using System.Collections.Generic;

using UnityEngine;

public abstract class ResourceEffect : Effect
{
    [SerializeField] protected bool perSecond;
    [SerializeField] protected ResourceDictionary affectedResources;

    protected ResourcesManager m_RM;

    private void OnEnable()
    {
        m_RM = ResourcesManager.Instance;
    }

    public float this[ResourceType type] => affectedResources[type];

    protected ICollection<ResourceType> GetResourceTypes() => affectedResources.Keys;

    protected void ScaleEffectPerSecond()
    {
        if (perSecond)
            affectedResources.Scale(Time.deltaTime);
    }
}
