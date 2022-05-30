using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Activity : MonoBehaviour
{
    [SerializeField] protected ResourceCosts Costs;
    [SerializeField] protected ResourceCosts Production;

    [SerializeField] private ActivityRepresentation Representation;


    public Action<Activity> onPressed;
    public Action onActive;
    public Action onStopped;

    private void OnEnable()
    {
        ActivitiesManager.Instance.RegisterActivity(this);

        if (Representation is not null)
        {
            Representation.UpdateWithNormalColor();
            onStopped = Representation.UpdateWithNormalColor;
            onActive = Representation.UpdateWithActiveColor;
        }
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
            onStopped?.Invoke();
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
