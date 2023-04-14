public class TaskSixteen
{
    public static void Main(String[] args)
    {
        int n = new Random().Next(1, 27);
        int count = 0;
        int value = n * 4;

        while (value <= 1000)
        {
            if(value >= 99)
            {
                count++;
            }

            value += n;
        }
    }
}
