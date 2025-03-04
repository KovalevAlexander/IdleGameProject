using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Units/HealthData")]
public class HealthData : Resource
{
    private void Awake()
    {
        type = ResourceType.Health;
    }
}
