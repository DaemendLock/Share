public class TaskNine
{
    public static void Main(String[] args)
    {
        string exitMessage = "exit";
        
        string lastMessage;
        
        do {
            lastMessage = Console.ReadLine() ?? "";
        } while (lastMessage.Equals(exitMessage) == false);
    }
}
