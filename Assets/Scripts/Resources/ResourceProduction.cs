using UnityEngine;

[CreateAssetMenu(menuName = "Game/Effects/Resources/Resource Production")]
public sealed class ResourceProduction : ResourceEffect
{
    public override bool CanApply()
    {
        foreach (var resourceType in GetResourceTypes())
            if (ReferenceManager.Instance.ResourcesManager.ResourceFilled(resourceType))
                return false;

        return true;
    }

    public override void Apply()
    {
        var scaled = ScaleEffectPerSecond(affectedResources);

        foreach (var resourceType in GetResourceTypes())
            ReferenceManager.Instance.ResourcesManager.IncreaseResource(resourceType, scaled[resourceType]);
    }
}
