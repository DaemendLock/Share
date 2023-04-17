public class TaskTwelveThree
{
    public static void Main(String[] args)
    {
        const string ExitCommand = "exit";
        const string SumCommand = "sum";

        int arrayLength = 1;
        int[] numbers = new int[arrayLength];
        int lastIndex = 0;

        string userInput;
        bool endInput = false;

        while (endInput == false)
        {
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case ExitCommand:
                    endInput = true;
                    continue;

                case SumCommand:
                    int sum = 0;

                    for (int i = 0; i < arrayLength; i++)
                    {
                        sum += numbers[i];
                    }

                    Console.WriteLine(sum);
                    break;

                default:
                    if (arrayLength == lastIndex)
                    {
                        int[] reallocBuffer = numbers;
                        arrayLength *= 2;
                        numbers = new int[arrayLength];

                        for (int i = 0; i < lastIndex; i++)
                        {
                            numbers[i] = reallocBuffer[i];
                        }
                    }

                    numbers[lastIndex] = Convert.ToInt32(userInput);
                    lastIndex++;
                    break;
            }
        }
    }
}
