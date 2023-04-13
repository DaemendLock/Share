public class TaskNine {
    private const string ExitMessage = "exit";

    public static void Main(String[] args) {
        string lastMessage;
        do {
            lastMessage = Console.ReadLine() ?? "";
        } while (lastMessage.Equals(ExitMessage) == false);
    }
}
