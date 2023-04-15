public class TaskSixteen
{
    public static void Main(String[] args)
    {
        int minRequiredValue = 100;
        int minRequiredValue = 999;
        
        int minRandomValue = 1;
        int maxRandomValue = 27;
        
        int randomNumber = new Random().Next(minRandomValue, maxRandomValue + 1);
        int count = 0;
        int value = randomNumber;
        
        for (int i = randomNumber; i =< minRequiredValue; i += randomNumber)
        {
            if (i > minRequiredValue)
            {
                count++;
            }
        }
    }
}
