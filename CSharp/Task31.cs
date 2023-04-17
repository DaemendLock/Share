public class TaskThirtyOne
{
    public static void Main(String[] args)
    {
        int arrayLength = 10;
        int randomNumberMaxValue = 9;
        int[] numbers = new int[arrayLength];

        Random random = new Random();

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next(randomNumberMaxValue + 1);
        }

        PrintArray(numbers);

        Shuffle(numbers, random);

        PrintArray(numbers);
        
    }

    private static void Shuffle(int[] numbers, Random randomValuesSource)
    {
        Shuffle(numbers, randomValuesSource, numbers.Length * 2);
    }

    private static void Shuffle(int[] numbers, Random randomValuesSource, int shuffleDepth)
    {
        for (int i = 0; i < shuffleDepth; i++)
        {
            int swapWith = randomValuesSource.Next(1, numbers.Length);
            (numbers[0], numbers[swapWith]) = (numbers[swapWith], numbers[0]);
        }
    }

    private static void PrintArray(int[] numbers)
    {
        foreach (int number in numbers)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }
}
