public class TaskThirtySeven
{
    public static void Main(string[] args)
    {
        const string ExitCommand = "exit";
        const string SumCommand = "sum";

        bool exitRequested = false;
        string userInput;

        List<int> numbers = new List<int>();

        while (exitRequested == false)
        {
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case ExitCommand:
                    exitRequested = true;
                    break;

                case SumCommand:
                    Console.WriteLine(GetSum(numbers));
                    break;

                default:
                    numbers.Add(ParseNumberOrZero(userInput));
                    break;

            }
        }
    }

    public static int GetSum(List<int> numbers)
    {
        int sum = 0;

        foreach (int number in numbers)
        {
            sum += number;
        }

        return sum;
    }

    public static int ParseNumberOrZero(string userInput)
    {
        if (int.TryParse(userInput, out int newNumber))
        {
            return newNumber;
        }

        return 0;
    }
}
