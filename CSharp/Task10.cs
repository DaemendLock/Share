public class TaskTen
{
    public static void Main(String[] args)
    {
        byte CycleIncrement = 7;
        byte FirstValue = 5;
        byte LastValue = 96;
        
        for (byte i = FirstValue; i <= LastValue; i += CycleIncrement)
        {
            Console.Write($"{i} ");
        }
    }
}
