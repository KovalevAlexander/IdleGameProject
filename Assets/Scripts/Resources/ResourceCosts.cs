using System.Collections.Generic;

using UnityEngine;

using RotaryHeart.Lib.SerializableDictionary;
public class ResourceCosts : ActivityRequirements
{
    [SerializeField] private Costs Costs;
    [SerializeField] private bool perSecond;

    public override bool AreMet
    {
        get
        {
            var RM = ResourcesManager.Instance as ResourcesManager;
            var requiredResources = GetRequiredResourceTypes();

            foreach (var resource in requiredResources)
            {
                if (RM.GetResource(resource).Value < Costs[resource])
                {
                    return false;
                }
            }

            requiredResources = GetRequiredResourceTypes();

            foreach (var resource in requiredResources)
            {
                if (!RM.GetResource(resource).Maxed)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public ICollection<ResourceType> GetRequiredResourceTypes()
    {
        return Costs.Keys;
    }

    public float this[ResourceType type]
    {
        get
        {
            return Costs[type];
        }
    }
}

[System.Serializable]
public class Costs : SerializableDictionaryBase<ResourceType, float> { }