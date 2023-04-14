public class TaskEight
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Write message:");
        string message = Console.ReadLine() ?? "";
        Console.WriteLine("Set repeatitions count:");
        
        for (uint repetitionsLeft = Convert.ToUInt32(Console.ReadLine()); repetitionsLeft != 0; repetitionsLeft--)
        {
            Console.Write(message);
        }
    }
}
