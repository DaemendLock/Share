public class TaskEight {
    public static void Main(String[] args) {
        Console.WriteLine("Write message:");
        string message = Console.ReadLine() ?? "";
        Console.WriteLine("Set repeatitions count:");
        uint repetitionsLeft = Convert.ToUInt32(Console.ReadLine());

        for (; repetitionsLeft != 0; repetitionsLeft--) {
            Console.Write(message);
        }
    }
}
