using UnityEngine;

[CreateAssetMenu(menuName = "Game/Effects/Resources/Resource Production")]
public sealed class ResourceProduction : ResourceEffect
{
    public override bool CanApply()
    {
        foreach (var resourceType in GetResourceTypes())
            if (ReferenceManager.Instance.RM.ResourceFilled(resourceType))
                return false;

        return true;
    }

    public override void Apply()
    {
        var scaled = ScaleEffectPerSecond(m_Resources);

        foreach (var resourceType in GetResourceTypes())
            ReferenceManager.Instance.RM.IncreaseResource(resourceType, scaled[resourceType]);
    }
}
