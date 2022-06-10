using UnityEngine;

public class ActivityAvailableState : ActivityState
{
    public ActivityAvailableState(Activity context, ActivityStateFactory activityStateFactory) : base(context, activityStateFactory)
    {
    }

    public override void CheckSwitchStates()
    {
        if (!m_Context.IsAvailable)
        {
            SwitchState(m_Factory.Unavailable());
            return;
        }
        if(m_Context.IsActive)
        {
            SwitchState(m_Factory.Active());
            return;
        }

        m_Context.onAvailable?.Invoke();
    }

    public override void EnterState()
    {
        m_Context.onAvailable?.Invoke();
    }

    public override void ExitState()
    {
        
    }

    public override void Run()
    {
        CheckSwitchStates();
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }


    protected override void UpdateStates()
    {
        throw new System.NotImplementedException();
    }
}
