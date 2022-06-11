public abstract class ActivityState : BaseState
{
    protected Activity m_Context;
    protected ActivityStateFactory m_Factory;

    public ActivityState(Activity context, ActivityStateFactory factory)
    {
        m_Context = context;
        m_Factory = factory;
    }

    protected override void SwitchState(IState newState)
    {
        ExitState();

        newState.EnterState();

        m_Context.State = (ActivityState)newState;
    }

    public virtual void Run()
        => CheckSwitchStates();

    public override void UpdateState()
        => CheckSwitchStates();

    public override void ExitState() { }
}
