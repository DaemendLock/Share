public class TaskThirtyNine
{
    public static void Main(String[] args)
    {
        Player player = new Player(10, 10);

        Paintbrush.Draw(player);
    }
}

public class Player
{
    private int _postionX;
    private int _positionY;

    public int X => _postionX;
   
    public int Y => _positionY;

    public Player(int positionX, int positionY)
    {
        _postionX = positionX;
        _positionY = positionY;
    }
}

public static class Paintbrush
{
    private static readonly string _playerModel = "1";

    public static void Draw(Player player)
    {
        Console.Clear();

        Console.SetCursorPosition(player.X, player.Y);
        Console.Write(_playerModel);
    }
}
