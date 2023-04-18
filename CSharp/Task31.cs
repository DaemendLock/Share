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
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            int swapWith = randomValuesSource.Next(i, numbers.Length);
            (numbers[i], numbers[swapWith]) = (numbers[swapWith], numbers[i]);
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
