using state_machine_pattern.StateMachinePattern.Objects;

namespace state_machine_pattern.StateMachinePattern.Managers;

public class GameManager
{
    private Player _player;
    
    public GameManager()
    {
        _player = new();
    }

    public void Update()
    {
        _player.Update();
    }

    public void Draw()
    {
        _player.Draw();
    }
}