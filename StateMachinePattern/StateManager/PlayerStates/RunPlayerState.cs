using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using state_machine_pattern.StateMachinePattern.Core;
using state_machine_pattern.StateMachinePattern.Managers;
using state_machine_pattern.StateMachinePattern.Objects;

namespace state_machine_pattern.StateMachinePattern.StateManager.PlayerStates;

public class RunPlayerState : IPlayerState
{
    public Player Player { get; }
    
    public RunPlayerState(Player player) => Player = player;

    public void Enter()
    {
        Player.Texture.SetData([Color.CadetBlue]);
        Player.Speed *= 2f;
    }

    public void Exit() => Player.Speed /= 2f;

    public void Update()
    {
        Player.Direction = Vector2.Zero;
        
        if (InputManager.IsKeyDown(Keys.W)) Player.Direction.Y -= 1;
        if (InputManager.IsKeyDown(Keys.A)) Player.Direction.X -= 1;
        if (InputManager.IsKeyDown(Keys.S)) Player.Direction.Y += 1;
        if (InputManager.IsKeyDown(Keys.D)) Player.Direction.X += 1;

        if (Player.Direction != Vector2.Zero) Player.Direction.Normalize();
        
        Player.Position += Player.Direction * Player.Speed * Globals.Time;
        
        if (!InputManager.IsKeyDown(Keys.LeftShift)) Player.StateMachine.ChangeState(Player.WalkState);
        if (Player.Direction == Vector2.Zero) Player.StateMachine.ChangeState(Player.IdleState);
    }
}