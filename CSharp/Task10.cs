public class TaskTen
{
    public static void Main(String[] args)
    {
        byte CycleIncrement = 7;
        byte FirstValue = 5;
        byte LastValue = 96;
        
        for (byte currentValue = FirstValue; currentValue <= LastValue; currentValue += CycleIncrement)
        {
            Console.Write($"{currentValue} ");
        }
    }
}
