public class TaskSixteen
{
    public static void Main(String[] args)
    {
        int randomNumber = new Random().Next(int.MaxValue >> 1);
        int closestNumber = randomNumber;
        int power = 0;

        while(closestNumber != 0)
        {
            power++;
            closestNumber >>= 1;
        }

        closestNumber = 1 << power;

        Console.WriteLine($"{randomNumber} {power} {closestNumber}");
    }
}
