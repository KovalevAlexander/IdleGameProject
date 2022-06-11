public sealed class ActivityUnavailableState : ActivityState
{
    public ActivityUnavailableState(Activity context, ActivityStateFactory activityStateFactory) 
        : base(context, activityStateFactory) { }

    public override void CheckSwitchStates()
    {
        if (m_Context.IsAvailable)
        {
            if(m_Context.IsActive)
            {
                SwitchState(m_Factory.Active());
                return;
            }
            
            SwitchState(m_Factory.Available());
            return;
        }

        m_Context.onUnavailable?.Invoke();
    }

    public override void EnterState() 
        => m_Context.onUnavailable?.Invoke();
}