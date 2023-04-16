public class TaskTwelveFive
{
    public static void Main(String[] args)
    {
        int arrayLength = 10;
        int maxRandomValue = 9;
        int[] numbers = new int[arrayLength];

        Random random = new Random();

        for (int i = 0; i < arrayLength; i++)
        {
            numbers[i] = random.Next(maxRandomValue + 1);
            Console.Write(numbers[i]);
        }

        Console.WriteLine();

        for (int i = 0; i < arrayLength; i++)
        {
            for (int j = 1; j < arrayLength; j++)
            {
                if (numbers[j-1] > numbers[j])
                {
                    (numbers[i], numbers[j]) = (numbers[j], numbers[i]);
                }
            }
        }

        bool swapped = true;

        while (swapped)
        {
            swapped = false;

            for (int i = 1; i < arrayLength; i++)
            {
                if (numbers[i - 1] > numbers[i])
                {
                    (numbers[i - 1], numbers[i]) = (numbers[i], numbers[i - 1]);
                    swapped = true;
                }
            }

            arrayLength--;
        }

        foreach (int i in numbers)
        {
            Console.Write(i);
        }
    }
}
