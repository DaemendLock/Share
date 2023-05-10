using System;
using static Utils;

public class Task55
{
    public static void Main(String[] args)
    {
        List<Can> cans = new List<Can>()
        {
            new Can("tsumuri", 80, 417),
            new Can("Kaima", 88, 301),
            new Can("Asto", 88, 291),
            new Can("DaemendLock", 88, 25680),
            new Can("berubetto~~", 88, 23240),
            new Can("Netr1X", 88, 22950),
            new Can("Lazaria", 88, 83100),
            new Can("Apparition", 88, 481),
            new Can("MagicAndy", 88, 424),
            new Can("Psycho", 88, 317),
        };

        int currentYear = DateTimeOffset.Now.Year;
        Console.WriteLine(string.Join(Environment.NewLine, cans.Where(can => can.Made + can.ExpireTime < currentYear)));
    }
}

public class Can
{
    public readonly string Title;
    public readonly int Made;
    public readonly int ExpireTime;

    public Can(string title, int made, int expireTime)
    {
        Title = title;
        Made = made;
        ExpireTime = expireTime;
    }

    public override string ToString()
    {
        return $"{Title}: {Made}/{ExpireTime + Made}";
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
