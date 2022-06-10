using System;
using UnityEngine;

public abstract class Activity : IRepresentable, IDisposable
{
    public Action<Activity> onPressed;

    public Action onActivated;
    public Action onStopped;
    public Action onUnavailable;
    public Action onAvailable;

    protected ActivityState m_CurrentState;
    protected ActivityStateFactory m_States;

    protected ActivityData m_Data;
    protected ActivityRepresentation m_Representation;

    public string Name => m_Data.Name;
    public ActivityType Type => m_Data.Type;
    public IRepresentation Representation
    {
        get => m_Representation;
        set => m_Representation = value as ActivityRepresentation;
    }

    public ActivityState State { get => m_CurrentState; set => m_CurrentState = value; }

    public ActivityData ActivityData => m_Data;

    public RepresentationColorData ColorData => m_Data.ColorData;

    public Activity(ActivityData data)
    {
        m_Data = data;

        m_States = new ActivityStateFactory(this);

        if (IsActive)
            m_CurrentState = m_States.Active();
        if (IsAvailable)
            m_CurrentState = m_States.Available();
        else m_CurrentState = m_States.Unavailable();

        m_CurrentState.EnterState();
    }

    public void Update()
    {
        m_CurrentState.UpdateState();
    }

    public virtual void Run()
    {
        m_CurrentState.Run();
    }

    public void OnPressed()
    {
        onPressed?.Invoke(this);
    }

    public bool IsAvailable => m_Data.Requirements.CanApply() && m_Data.Production.CanApply();

    public bool IsActive => ActivitiesManager.IsAlive && ActivitiesManager.Instance.IsActive(this);

    public void Dispose()
    {
        m_Representation = null;

        onActivated = null;
        onStopped = null;
        onUnavailable = null;
        onAvailable = null;
}
}
