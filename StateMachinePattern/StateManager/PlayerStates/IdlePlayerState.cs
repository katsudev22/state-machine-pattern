using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using state_machine_pattern.StateMachinePattern.Managers;
using state_machine_pattern.StateMachinePattern.Objects;

namespace state_machine_pattern.StateMachinePattern.StateManager.PlayerStates;

public class IdlePlayerState : IPlayerState
{
    public Player Player { get; }

    public IdlePlayerState(Player player)
    {
        Player = player;
    }
    
    public void Enter() =>
        Player.Texture.SetData([Color.IndianRed]);

    public void Exit() { }

    public void Update()
    {
        bool playerIsMoving = InputManager.IsKeyDown(Keys.D) || InputManager.IsKeyDown(Keys.A) || InputManager.IsKeyDown(Keys.W) || InputManager.IsKeyDown(Keys.S);
        if (playerIsMoving) Player.StateMachine.ChangeState(Player.WalkState);
    }
}