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
            ResourcesManager.Instance.DecreseResource(resource, Costs[resource]);
        }

        resourceTypes = Production.GetResourceTypes();

        foreach (var resource in resourceTypes)
        {
            ResourcesManager.Instance.IncreaseResource(resource, Production[resource]);
        }

        ActivitiesManager.Instance.AssignCurrentActivity(null);
        onStopped?.Invoke();
    }
}
