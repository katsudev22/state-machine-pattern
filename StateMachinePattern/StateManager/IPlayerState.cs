using state_machine_pattern.StateMachinePattern.Objects;

namespace state_machine_pattern.StateMachinePattern.StateManager;

public interface IPlayerState
{
    public Player Player { get; }
    
    public void Enter();
    public void Exit();
    public void Update();
}