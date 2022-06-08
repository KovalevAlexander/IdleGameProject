using System.Collections.Generic;

using UnityEngine;

using RotaryHeart.Lib.SerializableDictionary;

[CreateAssetMenu(menuName = "Game/Activities/Resource Requirment")]
public class ResourceCosts : ActivityRequirements
{
    [SerializeField] private ResourceDictionary Costs;
    [SerializeField] private bool perSecond;

    private float m_TimeModifier = (1/60);
    public override bool AreMet
    {
        get
        {
            return Check();
        }
    }

    private bool Check()
    {
        var RM = ResourcesManager.Instance;

        foreach (var resourceType in GetRequiredResourceTypes())
        {
            var cost = ResolveCost(resourceType);

            if (RM.GetResource(resourceType).Value < cost)
            {
                return false;
            }
        }

        return true;
    }

    private float ResolveCost(ResourceType resource)
    {
        var cost = Costs[resource];

        if (perSecond)
            cost = ScalePerSecond(cost);

        return cost;
    }

    private float ScalePerSecond(float value) => value * m_TimeModifier;
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
public class ResourceDictionary : SerializableDictionaryBase<ResourceType, float> { }