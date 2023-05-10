using static Utils;

public class TaskCarService
{
    public static void Main(String[] args)
    {
        List<Criminal> criminals = new List<Criminal>();

        criminals.Add(new Criminal("Nosize", 1, false, 1 , 1));

        int lookupDelta = 10;

        int lookupHeight = ForceReadInt("Write height");
        int lookupWeight = ForceReadInt("Write weight");
        int lookupNation = ForceReadInt("Write nation");

        IEnumerable<Criminal> suspects = criminals.Where(criminal => criminal.Matches(lookupHeight, lookupWeight, lookupNation, lookupDelta, lookupDelta) && criminal.Imprisoned == false);
        Console.WriteLine("Found "+suspects.Count());

        foreach (Criminal criminal in suspects)
        {
            Console.WriteLine(criminal);
        }
    }
}

public class Criminal
{
    public readonly string Fullname;
    public readonly int Nation;

    public Criminal(string fullname, int nation, bool imprisoned, int height, int weight)
    {
        Fullname = fullname;
        Nation = nation;
        Imprisoned = imprisoned;
        Height = height;
        Weight = weight;
    }

    public bool Imprisoned { get; private set; }
    public int Height { get; private set; }
    public int Weight { get; private set; }

    public bool Matches(int height, int weight, int nation, int deltaHeight = 0, int deltaWeight = 0)
    {
        bool result = Math.Abs(height - Height) <= deltaHeight;
        result &= Math.Abs(weight - Weight) <= deltaWeight;
        result &= nation == Nation;
        return result;
    }

    public override string ToString()
    {
        return $"Criminal \"{Fullname}\", H{Height} W{Weight} N{Nation}. Imprinosed: {Imprisoned}";
    }
}

public static class Utils
{
    public readonly static Random Random = new Random();

    public static string ReadResponse(string message)
    {
        Console.WriteLine(message);

        return Console.ReadLine();
    }

    public static int ForceReadInt(string message = "Write number.", int minValue = int.MinValue, int maxValue = int.MaxValue)
    {
        Console.WriteLine(message);

        int result;

        while (int.TryParse(Console.ReadLine(), out result) == false || result < minValue || result >= maxValue)
        {
            Console.Error.WriteLine("Failed to read. Try again.");
        }

        return result;
    }

    public static int? ReadChoose(string message, params string[] responses)
    {
        foreach (string resposne in responses)
        {
            Console.WriteLine("-" + resposne);
        }

        string choice = ReadResponse(message);

        for (int i = 0; i < responses.Length; i++)
        {
            if (responses[i].Equals(choice, StringComparison.OrdinalIgnoreCase))
            {
                return i;
            }
        }

        Console.Error.WriteLine("Failed to read choose.");
        return null;
    }
}
