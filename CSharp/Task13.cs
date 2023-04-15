public class TaskThirteen
{
    public static void Main(String[] args)
    {
        const string GuessCommand = "guess";
        const string SumCommand = "sum";
        const string RepeatCommand = "repeat";
        const string ExitCommand = "exit";
        
        string lastCommand;
        
        do
        {
            Console.WriteLine("What is your command? sum? guess? repeat?");
            lastCommand = Console.ReadLine() ?? "";
            
            switch (lastCommand) {
                case GuessCommand:
                    Console.WriteLine("Guess number from 0 to 100:");
                    int guessedNumber = Convert.ToInt32(Console.ReadLine());
                    
                    while(guessedNumber > 100)
                    {
                        Console.WriteLine("Don't cheat. From 0 to 100.");
                        guessedNumber = Convert.ToInt32(Console.ReadLine());
                    }
                    
                    int randomNumber = new Random().Next(100);

                    if(guessedNumber == randomNumber)
                    {
                        Console.WriteLine($"You guessed {randomNumber} right.");
                    } else
                    {
                        Console.WriteLine($"You didn't guess {randomNumber} right.");
                    }
                    
                    break;
                    
                case SumCommand:
                    Console.WriteLine("Number to sum to:");
                    int result = Convert.ToUInt32(Console.ReadLine());
                    result = (result * result + result) >> 1;
                    Console.WriteLine(result);
                    break;
                    
                case RepeatCommand:
                    Console.WriteLine("Text to repeat:");
                    Console.WriteLine(Console.ReadLine() ?? "Null");
                    break;
                    
                case ExitCommand:
                    continue;
                    
                default:
                    throw new Exception("Unknown command " + lastCommand);
            };
        } while (lastCommand.Equals(ExitCommand) == false);
    }
}
