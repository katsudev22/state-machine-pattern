using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using state_machine_pattern.StateMachinePattern.Core;
using state_machine_pattern.StateMachinePattern.StateManager;
using state_machine_pattern.StateMachinePattern.StateManager.PlayerStates;

namespace state_machine_pattern.StateMachinePattern.Objects;

public class Player
{
    public Texture2D Texture;
    public Vector2 Position;
    public Rectangle Bounds;
    public Vector2 Direction;
    public float Speed;
    
    public StateMachine StateMachine;
    public IdlePlayerState IdleState;
    public WalkPlayerState WalkState;
    public RunPlayerState RunState;
    
    public Player()
    {
        Texture = new(Globals.GraphicsDevice, 1, 1);
        Texture.SetData([Color.White]);
        Position = new(Globals.GameWindow.X / 2, Globals.GameWindow.Y / 2);
        Speed = 300f;
        
        UpdateBounds();

        IdleState = new IdlePlayerState(this);
        WalkState = new WalkPlayerState(this);
        RunState = new RunPlayerState(this);
        
        StateMachine = new(IdleState);
    }

    public void Update()
    {
        UpdateBounds();
        StateMachine.Update();
    }

    public void Draw() =>
        Globals.SpriteBatch.Draw(Texture, Position, Bounds, Color.White, 0f, new(25, 25), 1f, SpriteEffects.None, 0f);
    
    private void UpdateBounds()
    {
        int width = 50;
        int height = 50;

        Bounds = new Rectangle(
            (int)Position.X - width / 2,
            (int)Position.Y - height / 2,
            width,
            height
        );
    }
}