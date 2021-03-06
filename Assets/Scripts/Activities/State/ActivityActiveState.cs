using System.Runtime.CompilerServices;

public sealed class ActivityActiveState : ActivityState
{
    public ActivityActiveState(Activity context, ActivityStateFactory activityStateFactory) 
        : base(context, activityStateFactory) { }

    public override void CheckSwitchStates()
    {
        if (!m_Context.IsAvailable)
        {
            SwitchState(m_Factory.Unavailable());
            return;
        }

        if (!m_Context.IsActive)
        {
            SwitchState(m_Factory.Available());
            return;
        }

        m_Context.onActivated?.Invoke();
    }

    public override void EnterState() 
        => m_Context.onActivated?.Invoke();

    public override void ExitState() 
        => m_Context.onStopped?.Invoke();

    public override void Run()
    {
        ApplyEffects();

        base.Run();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void ApplyEffects()
    {
        m_Context.ActivityData.Requirements.Apply();
        m_Context.ActivityData.Production.Apply();
    }
}