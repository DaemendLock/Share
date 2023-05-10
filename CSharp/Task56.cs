using static Utils;

public class Task56
{
    public static void Main(String[] args)
    {
        List<Soldier> soldiers = new List<Soldier>()
        {
            new Soldier("tsumuri", 80, 417, 1),
            new Soldier("Kaima", 88, 301, 2),
            new Soldier("Asto", 88, 291, 3),
            new Soldier("DaemendLock", 88, 25680, 4),
            new Soldier("berubetto~~", 88, 23240, 5),
            new Soldier("Netr1X", 88, 22950, 6),
            new Soldier("Lazaria", 88, 83100, 7),
            new Soldier("Apparition", 88, 481, 8),
            new Soldier("MagiSoldierdy", 88, 424, 9),
            new Soldier("Psycho", 88, 317, 10),
        };

        var request = from Soldier soldier in soldiers
                      select new
                      {
                          Name = soldier.Name,
                          Rank = soldier.Rank
                      };

        foreach (var value in request)
        {
            Console.WriteLine(value.Name + " " + value.Rank);
        }

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
}
