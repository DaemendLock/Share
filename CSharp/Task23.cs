public class TaskTwelveThree
{
    public static void Main(String[] args)
    {
        const string ExitCommand = "exit";
        const string SumCommand = "sum";

        int arrayLength = 5;
        int[] numbers = new int[arrayLength];
        int lastIndex = 0;

        string lastCommand;
        int lastNumber;

        do
        {
            lastCommand = Console.ReadLine();
            switch (lastCommand)
            {
                case ExitCommand:
                    continue;

                case SumCommand:
                    int sum = 0;

                    for (int i = 0; i < arrayLength; i++)
                    {
                        sum+= numbers[i];
                    }

                    Console.WriteLine(sum);
                    break;

                default:
                    lastNumber = Convert.ToInt32(lastCommand);

                    if (arrayLength == lastIndex)
                    {
                        int[] reallocBuffer = numbers;
                        arrayLength *= 2;
                        numbers = new int[arrayLength];

                        for(int i = 0; i < lastIndex; i++)
                        {
                            numbers[i] = reallocBuffer[i];
                        }
                    }

                    numbers[lastIndex] = lastNumber;
                    lastIndex++;
                    break;
            }
        } while (lastCommand != ExitCommand);
    }
}
