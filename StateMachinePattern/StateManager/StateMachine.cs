namespace state_machine_pattern.StateMachinePattern.StateManager;

public class StateMachine
{
    public IPlayerState CurrentState { get; private set; }

    public StateMachine(IPlayerState initialState)
    {
        CurrentState = initialState;
        CurrentState.Enter();
    }

    public void ChangeState(IPlayerState newState)
    {
        if (CurrentState == newState || newState == null) return;

        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }

    public void Update()
    {
        if (CurrentState == null) return;
        CurrentState.Update();
    }
}