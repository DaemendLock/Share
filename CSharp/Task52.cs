public class Task52
{
    public static void Main(String[] args)
    {
        List<Criminal> criminals = new List<Criminal>() { new Criminal("Nosize", "Anti"),
        new Criminal("Snek", "Hissed too loudly.")};

        string AmnestiCrime = "Anti";

        Console.WriteLine("Old criminals list:");

        foreach (Criminal criminal in criminals)
        {
            Console.WriteLine(criminal);
        }

        criminals = criminals.Where(criminal => criminal.Crime.StartsWith(AmnestiCrime)).ToList();
        Console.WriteLine("New criminals list:");

        foreach (Criminal criminal in criminals)
        {
            Console.WriteLine(criminal);
        }
    }
}

public class Criminal
{
    public readonly string Fullname;
    public readonly string Crime;

    public Criminal(string fullname, string crime)
    {
        Fullname = fullname;
        Crime = crime;
    }

    public override string ToString()
    {
        return $"Criminal: \"{Fullname}\", Crime: \"{Crime}\"";
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
