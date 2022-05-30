using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionActivity : Activity
{
    public override void Run()
    {
        base.Run();

        var resourceTypes = Costs.GetResourceTypes();

        foreach (var resource in resourceTypes)
        {
            ResourcesManager.Instance.GetResource(resource).Substract(Costs[resource]);
        }

        resourceTypes = Production.GetResourceTypes();

        foreach (var resource in resourceTypes)
        {
            ResourcesManager.Instance.GetResource(resource).Add(Production[resource]);
        }

        ActivitiesManager.Instance.AssignCurrentActivity(null);
    }
}
