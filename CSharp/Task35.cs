public class TaskThirtySeven
{
    public static void Main(string[] args)
    {
        const string exitCommand = "exit";
        const string sumCommand = "sum";

        bool exitRequested = false;
        string userInput;

        List<int> numbers = new List<int>();

        while (exitRequested == false)
        {
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case exitCommand:
                    exitRequested = true;
                    break;

                case sumCommand:
                    Console.WriteLine(GetSum(numbers));
                    break;

                default:
                    int newNumber;

                    if (int.TryParse(userInput, out newNumber)) {
                        numbers.Add(newNumber);
                    }

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
}
