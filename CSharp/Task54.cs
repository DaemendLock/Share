public class Task54
{
    public static void Main(String[] args)
    {
        int takeTop = 3;

        List<Player> players = new List<Player>()
        {
            new Player("tsumuri", 80, 41730),
            new Player("Kaima", 88, 30170),
            new Player("Asto", 88, 29160),
            new Player("DaemendLock", 88, 25680),
            new Player("berubetto~~", 88, 23240),
            new Player("Netr1X", 88, 22950),
            new Player("Lazaria", 88, 83100),
            new Player("Apparition", 88, 48120),
            new Player("MagicAndy", 88, 42420),
            new Player("Psycho", 88, 31770),
        };

        Console.WriteLine("Top level:");
        Console.WriteLine(string.Join(Environment.NewLine, players.OrderByDescending(player => player.Level).Take(takeTop)));
        Console.WriteLine("Top score:");
        Console.WriteLine(string.Join(Environment.NewLine, players.OrderByDescending(player => player.Score).Take(takeTop)));
    }
}

public class Player
{
    public Player(string nickname, int level, int power)
    {
        Nickname = nickname;
        Score = power;
        Level = level;
    }
    public string Nickname { get; private set; }
    public int Score { get; private set; }
    public int Level { get; private set; }

    public override string ToString()
    {
        return $"{Nickname} - Lv.{Level}. (Score: {Score})";
    }
}
