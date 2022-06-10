using UnityEngine;

[CreateAssetMenu(menuName = "Game/Effects/Resources/Resource Production")]
public sealed class ResourceProduction : ResourceEffect
{
    public override bool CanApply()
    {
        foreach (var resourceType in GetResourceTypes())
            if (m_RM.ResourceFilled(resourceType))
                return false;

        return true;
    }

    public override void Apply()
    {
        ScaleEffectPerSecond();

        foreach (var resourceType in GetResourceTypes())
            m_RM.IncreaseResource(resourceType, affectedResources[resourceType]);
    }
}
