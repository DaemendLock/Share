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
    public Player(int positionX, int positionY)
    {
        PositionX = positionX;
        PositionY = positionY;
    }

    public int PositionX { get; private set; }
    public int PositionY { get; private set; }
}

public static class Paintbrush
{
    private static readonly string _playerModel = "1";

    public static void Draw(Player player)
    {
        Console.Clear();

        Console.SetCursorPosition(player.PositionX, player.PositionY);
        Console.Write(_playerModel);
    }
}
