public abstract class BaseState : IState
{
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    public abstract void CheckSwitchStates();

    protected abstract void UpdateStates();
    protected abstract void SwitchState(IState newState);
}
