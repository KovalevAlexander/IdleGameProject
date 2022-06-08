using System;

public abstract class Activity : IRepresentable
{
    public Action<Activity> onPressed;
    public Action onActivated;
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

    public RepresentationColorData ColorData => m_Data.ColorData;

    public Activity(ActivityData data)
    {
        m_Data = data;

        ResourcesManager.Instance.onResourcesUpdated += HandleResourceUpdate;
    }

    public virtual void Run()
    {
        if (!IsAvailable())
        {
            ActivitiesManager.Instance.StopActivity(this);
            return;
        }
    }

    public void OnPressed()
    {
        onPressed?.Invoke(this);
    }

    public virtual bool IsAvailable()
    {
        return m_Data.Requirements.AreMet && m_Data.Production.CanProduce;
    }

    private void HandleResourceUpdate()
    {
        //Race With Active
        if (IsAvailable())
        {
            onAvailable?.Invoke();
        }
        else
            onUnavailable?.Invoke();
    }
}
