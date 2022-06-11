public class ActivityInitialState : ActivityState
{
    public ActivityInitialState(Activity context, ActivityStateFactory factory) 
        : base(context, factory) { }

    public override void EnterState() 
        => CheckSwitchStates();

    public override void CheckSwitchStates()
    {
        if (m_Context.IsActive)
            SwitchState(m_Factory.Active());
        else if(m_Context.IsAvailable)
            SwitchState(m_Factory.Available());
        else if(!m_Context.IsAvailable)
            SwitchState(m_Factory.Unavailable());
    }
}
