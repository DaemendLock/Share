public class TaskFourteen
{
    public static void Main(String[] args)
    {
        int BorderWidth = 1;

        string name = Console.ReadLine();
        string fillingChar = Console.ReadLine();

        int lineLength = name.Length + 2 * BorderWidth;

        for (int i = 0; i < lineLength; i++)
        {
            Console.Write(fillingChar);
        }
        
        Console.WriteLine($"{Environment.NewLine}{fillingChar}{name}{fillingChar}{Environment.NewLine}");

        for (int i = 0; i < lineLength; i++)
        {
            Console.Write(fillingChar);
        }
    }
}
