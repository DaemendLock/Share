public class TaskSixteen
{
    public static void Main(String[] args)
    {
        const int minRandomValue = 1;
        const int maxRandomValue = 27;
        
        int randomNumber = new Random().Next(minRandomValue, maxRandomValue + 1);
        int count = 0;
        int value = randomNumber;
        
        for (int i = randomNumber; i < 1000; i += randomNumber)
        {
            if (i > 99)
            {
                count++;
            }
        }
    }
}
