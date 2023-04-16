public class TaskTwelveTwo
{
    public static void Main(String[] args)
    {
        int arrayLength = 30;

        int randomMinValue = -9;
        int randomMaxValue = 9;

        int[] numbers = new int[arrayLength];

        Random random = new Random();

        for (int i = 0; i < arrayLength; i++)
        {
            numbers[i] = random.Next(randomMinValue, randomMaxValue);
        }
        
        for (int i = 1; i < arrayLength; i++)
        {
            if ((i == 0 || numbers[i] > numbers[i-1]) && (i == arrayLength - 1 || numbers[i] > numbers[i + 1]))
            {
                Console.Write(numbers[i] + " ");
            }
        }
    }
}
