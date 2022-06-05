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
    public Action onUnavailable;
    public Action onAvailable;

    private void Awake()
    {
#if UNITY_EDITOR
        if (Costs is null || Production is null)
        {
            Debug.LogError("Pleasu ensure that the " + gameObject.name + " activity has been set up correctly!", gameObject);
        }
#endif
    }

    private void OnEnable()
    {
        ActivitiesManager.Instance.RegisterActivity(this);

        if (Representation is not null)
        {
            onStopped = Representation.UpdateWithDisabledColor;
            onActive = Representation.UpdateWithActiveColor;
            onUnavailable = Representation.UpdateWithDisabledColor;
            onAvailable = Representation.UpdateWithNormalColor;

            CanActivate(); //To update the UI
        }

        ResourcesManager.Instance.onResourcesUpdated += HandleResourceUpdate;
    }

    private void OnDisable()
    {
#if !UNITY_EDITOR
        ActivitiesManager.Instance.RemoveActivity(this);

        ResourcesManager.Instance.onResourcesUpdated -= HandleResourceUpdate;
#endif
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
        onPressed?.Invoke(this);
    }

    public virtual bool CanActivate()
    {
        var requiredResources = Costs.GetResourceTypes();

        foreach (var resource in requiredResources)
        {
            if (ResourcesManager.Instance.GetResource(resource).Value < Costs[resource])
            {
                onUnavailable?.Invoke();
                return false;
            }   
        }

        requiredResources = Production.GetResourceTypes();

        foreach (var resource in requiredResources)
        {
            if (!ResourcesManager.Instance.GetResource(resource).Maxed)
            {
                onAvailable?.Invoke();
                return true;
            }
        }

        onUnavailable?.Invoke();
        return false;
    }

    private void HandleResourceUpdate()
    {
        CanActivate();
    }
}
