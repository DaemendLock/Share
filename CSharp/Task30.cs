public class TaskThirty
{
    public static void Main(String[] args)
    {
        Console.WriteLine(ReadInt());
    }

    private static int ReadInt()
    {
        int value;
        
        do {
            Console.WriteLine("Please enter number...");
        } while (int.TryParse(Console.ReadLine(), out value) == false);

        return value;
    }
}
