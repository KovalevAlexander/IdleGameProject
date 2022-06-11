using System;

public abstract class Activity : IRepresentable, IDisposable
{
    public Action onActivated;
    public Action onStopped;
    public Action onUnavailable;
    public Action onAvailable;

    public ActivityData ActivityData => m_Data;

    public RepresentationColorData ColorData => m_Data.ColorData;
    public string Name => m_Data.Name;
    public ActivityType Type => m_Data.Type;

    public IRepresentation Representation
    {
        get => m_Representation;
        set => m_Representation = value as ActivityRepresentation;
    }

    public ActivityState State 
    {   
        get => m_CurrentState; 
        set => m_CurrentState = value; 
    }

    public bool IsAvailable
        => m_Data.Requirements.CanApply() &&
            m_Data.Production.CanApply();

    public bool IsActive
        => ReferenceManager.Instance.ActivitiesManager.IsActive(this);

    protected ActivityState m_CurrentState;
    protected ActivityStateFactory m_States;

    protected ActivityData m_Data;
    protected ActivityRepresentation m_Representation;

    public Activity(ActivityData data)
    {
        m_Data = data;

        m_States = new ActivityStateFactory(this);
        m_CurrentState = m_States.Initial();
        m_CurrentState.EnterState();
    }

    public void Update() 
        => m_CurrentState.UpdateState();

    public virtual void Run() 
        => m_CurrentState.Run();

    //Activity Data reference is left untouched so it can be re-used
    public void Dispose()
    {
        m_Representation = null;

        onActivated = null;
        onStopped = null;
        onUnavailable = null;
        onAvailable = null;
    }
}
