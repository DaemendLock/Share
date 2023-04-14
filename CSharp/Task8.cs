public class TaskEight
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Write message:");
        string message = Console.ReadLine() ?? "";
        Console.WriteLine("Set repeatitions count:");
        
        int repeatitionsRequried = Convert.ToUInt32(Console.ReadLine());
        
        for (int i = repeatitionsRequried; i != 0; i--)
        {
            Console.Write(message);
        }
    }
}
