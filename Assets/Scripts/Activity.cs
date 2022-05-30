using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Activity : MonoBehaviour
{
    [SerializeField] protected ResourceCosts Costs;
    [SerializeField] protected ResourceCosts Production;

    public Action<Activity> onPressed;

    private void OnEnable()
    {
        ActivitiesManager.Instance.RegisterActivity(this);
    }

    private void OnDisable()
    {
        //ActivitiesManager.Instance.RemoveActivity(this);
    }

    public virtual void Run()
    {
        if (!CanActivate())
        {
            ActivitiesManager.Instance.AssignCurrentActivity(null);
            return;
        }
    }

    public void OnPressed()
    {
        onPressed.Invoke(this);
    }

    public virtual bool CanActivate()
    {
        var requiredResources = Costs.GetResourceTypes();
        foreach (var resource in requiredResources)
        {
            if (ResourcesManager.Instance.GetResource(resource).Value < Costs[resource])
            {
                return false;
            }
                
        }
        return true;
    }
}
