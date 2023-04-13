public class TaskThirteen {
    private const string GuessCommand = "guess";
    private const string SumCommand = "sum";
    private const string RepeatCommand = "repeat";
    private const string ExitCommand = "exit";

    public static void Main(String[] args) {
        string lastCommand;
        do {
            Console.WriteLine("What is your command? sum? guess? repeat?");
            lastCommand = Console.ReadLine() ?? "";
            switch (lastCommand) {
                case GuessCommand:
                    HandleGuessRequest();
                    break;
                case SumCommand:
                    HandleSumRequest();
                    break;
                case RepeatCommand:
                    HandleRepeatRequest();
                    break;
                case ExitCommand:
                    continue;
                default:
                    throw new Exception("Unknown command " + lastCommand);
            };
        } while (lastCommand.Equals(ExitCommand) == false);
    }
    private static void HandleGuessRequest() {
        Console.WriteLine("Guess number from 0 to 100:");
        byte guessedNumber = Convert.ToByte(Console.ReadLine());
        while(guessedNumber > 100) {
            Console.WriteLine("Don't cheat. From 0 to 100.");
            guessedNumber = Convert.ToByte(Console.ReadLine());
        }
        byte randomNumber = (byte) new Random().Next(100);

        if(guessedNumber == randomNumber) {
            Console.WriteLine($"You guessed {randomNumber} right.");
        } else {
            Console.WriteLine($"You didn't guess {randomNumber} right.");
        }
    }

    private static void HandleSumRequest() {
        Console.WriteLine("Number to sum to:");
        uint result = Convert.ToUInt32(Console.ReadLine());
        result = (result * result + result) >> 1;
        Console.WriteLine(result);
    }

    private static void HandleRepeatRequest() {
        Console.WriteLine("Text to repeat:");
        Console.WriteLine(Console.ReadLine() ?? "Null");
    }
}
