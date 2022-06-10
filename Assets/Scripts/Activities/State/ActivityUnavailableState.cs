using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityUnavailableState : ActivityState
{
    public ActivityUnavailableState(Activity context, ActivityStateFactory activityStateFactory) : base(context, activityStateFactory)
    {
    }

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
    {
        m_Context.onUnavailable?.Invoke();
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
