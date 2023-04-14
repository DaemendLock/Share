public class TaskEight
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Write message:");
        string message = Console.ReadLine() ?? "";
        Console.WriteLine("Set repeatitions count:");
        
        for (int i = Convert.ToUInt32(Console.ReadLine()); i != 0; i--)
        {
            Console.Write(message);
        }
    }
}
