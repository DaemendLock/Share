public class TaskThirty
{
    public static void Main(String[] args)
    {
        Console.WriteLine(ForceReadInt());
    }

    public static int ForceReadInt()
    {
        int value;

        while (int.TryParse(Console.ReadLine(), out value) == false);

        return value;
    }
}
