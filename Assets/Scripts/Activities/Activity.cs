using System;
using UnityEngine;

public abstract class Activity : IRepresentable
{
    public Action<Activity> onPressed;
    public Action onActive;
    public Action onStopped;
    public Action onUnavailable;
    public Action onAvailable;

    protected ActivityData m_Data;
    protected ActivityRepresentation m_Representation;

    public string Name => m_Data.Name;
    public ActivityType Type => m_Data.Type;
    public IRepresentation Representation
    {
        get => m_Representation;
        set => m_Representation = value as ActivityRepresentation;
    }
    public Activity(ActivityData data)
    {
        m_Data = data;

        var RM = ResourcesManager.Instance as ResourcesManager;
        RM.onResourcesUpdated += HandleResourceUpdate;

    }

    public virtual void Run()
    {
        if (!CanActivate())
        {
            var AM = ActivitiesManager.Instance as ActivitiesManager;
            AM.AssignCurrentActivity(null);
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
        return false;
    }

    private void HandleResourceUpdate()
    {
        CanActivate();
    }
}
