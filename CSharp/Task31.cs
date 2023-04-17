public class TaskThirtyOne
{
    public static void Main(String[] args)
    {
        int arrayLength = 10;
        int randomNumberMaxValue = 9;
        int[] numbers = new int [arrayLength];

        Random random = new Random();

        for (int i = 0; i < arrayLength; i++)
        {
            numbers[i] = random.Next(randomNumberMaxValue + 1);
            Console.Write(numbers[i]);
        }

        Shuffle(numbers, random);
        Console.WriteLine();

        for (int i = 0; i < arrayLength; i++)
        {
            Console.Write(numbers[i]);
        }
    }

    private static void Shuffle(int[] numbers, Random randomValuesSource)
    {
        Shuffle(numbers, randomValuesSource, numbers.Length);
    }

    private static void Shuffle(int[] numbers, Random randomValuesSource, int shuffleDepth)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            int swapWith = randomValuesSource.Next(numbers.Length);
            (numbers[0], numbers[swapWith]) = (numbers[swapWith], numbers[0]);
        }
    }

}
