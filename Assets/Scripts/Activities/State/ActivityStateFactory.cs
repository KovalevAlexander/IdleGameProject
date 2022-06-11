public sealed class ActivityStateFactory
{
    private readonly Activity m_Context;

    public ActivityStateFactory(Activity context) 
        => m_Context = context;

    public ActivityState Initial() => new ActivityInitialState(m_Context, this);
    public ActivityState Available() => new ActivityAvailableState(m_Context, this);
    public ActivityState Unavailable() => new ActivityUnavailableState(m_Context, this);
    public ActivityState Active() => new ActivityActiveState(m_Context, this);
}
