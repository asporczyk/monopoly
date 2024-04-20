namespace Monopoly.GameCore.Models;

public class Game
{
    public bool IsRunning { get; private set; }

    public void Start() => IsRunning = true;

    public void Reset() => IsRunning = false;
}