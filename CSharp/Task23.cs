public class TaskTwelveThree
{
    public static void Main(String[] args)
    {
        const string ExitCommand = "exit";
        const string SumCommand = "sum";

        int arrayLength = 5;
        int[] numbers = new int[arrayLength];
        int lastIndex = 0;
        int arraySum = 0;

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
                    Console.WriteLine(arraySum);
                    break;

                default:
                    lastNumber = Convert.ToInt32(lastCommand);
                    arraySum += lastNumber;

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
