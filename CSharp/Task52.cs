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

        criminals = criminals.Where(criminal => criminal.Crime.StartsWith(AmnestiCrime) == false).ToList();
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
