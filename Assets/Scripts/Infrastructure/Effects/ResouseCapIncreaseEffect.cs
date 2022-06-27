using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Effects/Resources/Resource Cap Increase")]
public class ResouseCapIncreaseEffect : ResourceEffect
{
    public override void Apply()
    {
        foreach (var resourceType in GetResourceTypes())
            ReferenceManager.Instance.ResourcesManager.IncreaseResourceCap(resourceType, affectedResources[resourceType]);
    }

    public override bool CanApply() 
        => true;
}
