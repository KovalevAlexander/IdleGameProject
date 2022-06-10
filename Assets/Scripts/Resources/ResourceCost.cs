using UnityEngine;

[CreateAssetMenu(menuName = "Game/Effects/Resources/Resource Cost")]
public sealed class ResourceCost : ResourceEffect
{
    public override bool CanApply()
    {
        ScaleEffectPerSecond();

        foreach (var resourceType in GetResourceTypes())
            if (!m_RM.ResourceHasMoreOrEqual(resourceType, affectedResources[resourceType]))
                return false;

        return true;
    }

    public override void Apply()
    {
        ScaleEffectPerSecond();

        foreach (var resourceType in GetResourceTypes())
            m_RM.DecreseResource(resourceType, affectedResources[resourceType]);
    }
}

