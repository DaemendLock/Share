public class TaskTen
{
    public static void Main(String[] args)
    {
        int cycleIncrement = 7;
        int firstValue = 5;
        int lastValue = 96;

        for (int i = firstValue; i <= lastValue; i += cycleIncrement)
        {
            Console.Write($"{i} ");
        }
    }
}
