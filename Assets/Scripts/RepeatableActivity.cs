using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatableActivity : Activity
{
    public override void Run()
    {
        base.Run();

        var resourceTypes = Costs.GetResourceTypes();

        foreach (var resource in resourceTypes)
        {
            ResourcesManager.Instance.GetResource(resource).Substract(Costs[resource] * Time.deltaTime);
        }

        resourceTypes = Production.GetResourceTypes();

        foreach (var resource in resourceTypes)
        {
            ResourcesManager.Instance.GetResource(resource).Add(Production[resource] * Time.deltaTime) ;
        }
    }

    public override bool CanActivate()
    {
        var requiredResources = Costs.GetResourceTypes();
        foreach (var resource in requiredResources)
        {
            if (ResourcesManager.Instance.GetResource(resource).Value < (Costs[resource] * Time.deltaTime))
            {
                return false;
            }

        }
        return true;
    }
}
