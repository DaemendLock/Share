public class TaskTwelveTwo
{
    public static void Main(String[] args)
    {
        int arrayLength = 30;

        int randomMinValue = -9;
        int randomMaxValue = 9;


        int[] array = new int[arrayLength];

        Random random = new Random();

        for (int i = 0; i < arrayLength; i++)
        {
            array[i] = random.Next(randomMinValue, randomMaxValue);
        }

        for (int i = 0; i < arrayLength; i++)
        {
            if ((i == 0 || array[i] > array[i-1]) && (i == arrayLength - 1 || array[i] > array[i + 1]))
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}
