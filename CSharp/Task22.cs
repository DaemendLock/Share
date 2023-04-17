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
        
        if (arrayLength == 1 || numbers[0] > numbers[1])
        {
            Console.Write(numbers[0] + " ");
        }
        
        for (int i = 1; i < arrayLength - 1; i++)
        {
            if (numbers[i] > numbers[i-1] && numbers[i] > numbers[i + 1]))
            {
                Console.Write(numbers[i] + " ");
            }
        }
        
        if (arrayLength > 1 && numbers[arrayLenth - 2] < numbers[arrayLength - 1]) {
            Console.Write(numbers[arrayLength - 1] + " ");
        }
    }
}
