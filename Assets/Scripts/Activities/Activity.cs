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

        if(!m_Data.InitiallyUnlocked)
            ReferenceManager.Instance.UnlockManager.LockActivity(this);

        m_States = new ActivityStateFactory(this);
        m_CurrentState = m_States.Initial();
        m_CurrentState.EnterState();
    }

    public static bool operator ==(Activity x, Activity y)
    {
        if (x is null)
        {
            if (y is null)
            {
                return true;
            }

            // Only the left side is null.
            return false;
        }
        // Equals handles case of null on right side.
        return x.Equals(y);
    }

    public static bool operator !=(Activity x, Activity y) => !(x == y);

    public bool Equals(Activity activity)
    {
        if (activity is null)
        {
            return false;
        }

        // Optimization for a common success case.
        if (Object.ReferenceEquals(this, activity))
        {
            return true;
        }

        // If run-time types are not exactly the same, return false.
        if (this.GetType() != activity.GetType())
        {
            return false;
        }

        // Return true if the fields match.
        // Note that the base class is not invoked because it is
        // System.Object, which defines Equals as reference equality.
        return this.ActivityData == activity.ActivityData;
    }

    public override bool Equals(object obj) => this.Equals(obj as Activity);

    public override int GetHashCode() => (ActivityData).GetHashCode();

    public void Update() 
        => m_CurrentState.UpdateState();

    public virtual void Run() 
        => m_CurrentState.Run();

    //Activity Data reference is left untouched so it can be re-used
    public void Dispose()
    {
        onActivated = null;
        onStopped = null;
        onUnavailable = null;
        onAvailable = null;
    }
}
