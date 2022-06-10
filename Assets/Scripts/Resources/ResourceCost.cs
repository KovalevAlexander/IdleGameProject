using UnityEngine;

[CreateAssetMenu(menuName = "Game/Effects/Resources/Resource Cost")]
public sealed class ResourceCost : ResourceEffect
{
    public override bool CanApply()
    {
        var scaled = ScaleEffectPerSecond(m_Resources);

        foreach (var resourceType in GetResourceTypes())
            if (!ReferenceManager.Instance.RM.ResourceHasMoreOrEqual(resourceType, scaled[resourceType]))
                return false;

        return true;
    }

    public override void Apply()
    {
        var scaled = ScaleEffectPerSecond(m_Resources);
        foreach (var resourceType in GetResourceTypes())
            ReferenceManager.Instance.RM.DecreseResource(resourceType, scaled[resourceType]);
    }
}

