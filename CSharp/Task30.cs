public class TaskThirty
{
    public static void Main(String[] args)
    {
        Console.WriteLine(ForceReadInt());
    }

    private static int ForceReadInt()
    {
        int value;

        while (TryRead(out value) == false);

        return value;
    }

    private static bool TryRead(out int value)
    {
        return int.TryParse(Console.ReadLine(), out value);
    }
}
