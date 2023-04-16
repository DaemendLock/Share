public class TaskTwelveSeven
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

        Console.WriteLine(Environment.NewLine + "Shift by: ");
        int shiftCount = (arrayLength - Convert.ToInt32(Console.ReadLine())) % arrayLength;

        for (int i = 0; i < shiftCount; i++)
        {
            for (int j = (i + shiftCount) % arrayLength; i != j; j = (j + shiftCount) % arrayLength)
            {
                (numbers[i], numbers[j]) = (numbers[j], numbers[i]);
            }
        }

        for (int i = 0; i < arrayLength; i++)
        {
            Console.Write(numbers[i]);
        }
    }
}
