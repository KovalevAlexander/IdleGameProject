using UnityEngine;

[CreateAssetMenu(menuName = "Game/Effects/Resources/Resource Cost")]
public sealed class ResourceCost : ResourceEffect
{
    public override bool CanApply()
    {
        var scaled = ScaleEffectPerSecond(affectedResources);

        foreach (var resourceType in GetResourceTypes())
            if (!ReferenceManager.Instance.ResourcesManager.ResourceHasMoreOrEqual(resourceType, scaled[resourceType]))
                return false;

        return true;
    }

    public override void Apply()
    {
        var scaled = ScaleEffectPerSecond(affectedResources);
        foreach (var resourceType in GetResourceTypes())
            ReferenceManager.Instance.ResourcesManager.DecreseResource(resourceType, scaled[resourceType]);
    }
}

