public class TaskTwentyEight
{
    public static void Main(String[] args)
    {
        Player player = new Player(0, 100, "AAAAAAA");

        player.Print();
    }
}

public class Player
{
    private ushort _serverId;
    private int _health;
    private string _name;

    public Player(ushort serverId, int health, string name)
    {
        _serverId = serverId;
        _health = health;
        _name = name;
    }

    public void Print()
    {
        Console.WriteLine($"Name: {_name}, Health: {_health}, Server Id: {_serverId}");
    }
}
