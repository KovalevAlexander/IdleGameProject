using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RotaryHeart.Lib.SerializableDictionary;
[CreateAssetMenu(menuName ="Game/ResourceCost")]
public class ResourceCosts : ScriptableObject
{
    [SerializeField] private Costs Costs;

    public ICollection<ResourceType> GetResourceTypes()
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