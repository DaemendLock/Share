public class Task57
{
    public static void Main(String[] args)
    {
        string moveLetter = "B";

        List<Soldier> soldiers1 = new List<Soldier>()
        {
            new Soldier("tsumuri", 80, 417, 1),
            new Soldier("Kaima", 88, 301, 2),
            new Soldier("Asto", 88, 291, 3),
            new Soldier("DaemendLock", 88, 25680, 4),
            new Soldier("berubetto~~", 88, 23240, 5),
        };

        List<Soldier> soldiers2 = new List<Soldier>()
        {
            new Soldier("Netr1X", 88, 22950, 6),
            new Soldier("Lazaria", 88, 83100, 7),
            new Soldier("Apparition", 88, 481, 8),
            new Soldier("MagiSoldierdy", 88, 424, 9),
            new Soldier("Psycho", 88, 317, 10),
        };

        Console.WriteLine("1st platoon before:");
        Console.WriteLine(string.Join(Environment.NewLine, soldiers1));
        Console.WriteLine("2nd platoon before:");
        Console.WriteLine(string.Join(Environment.NewLine, soldiers2));
        Console.WriteLine();

        var selection = soldiers1.Where(soldier => soldier.Name.StartsWith(moveLetter, StringComparison.OrdinalIgnoreCase)).ToList();
        soldiers1 = selection.Except(selection).ToList();
        soldiers2 = soldiers2.Union(selection).ToList();

        Console.WriteLine("1st platoon after:");
        Console.WriteLine(string.Join(Environment.NewLine, soldiers1));
        Console.WriteLine("2nd platoon after:");
        Console.WriteLine(string.Join(Environment.NewLine, soldiers2));
    }
}

public class Soldier
{
    public readonly string Name;

    public Soldier(string name, int weapon, int time, int rank)
    {
        Name = name;
        Weapon = weapon;
        Time = time;
        Rank = rank;
    }

    public int Weapon { get; private set; }
    public int Time { get; private set; }
    public int Rank { get; private set; }

    public override string ToString()
    {
        return Name;
    }
}
