public class TaskNine
{
    public static void Main(String[] args)
    {
        string ExitMessage = "exit";
        
        string lastMessage;
        
        do {
            lastMessage = Console.ReadLine() ?? "";
        } while (lastMessage.Equals(ExitMessage) == false);
    }
}
