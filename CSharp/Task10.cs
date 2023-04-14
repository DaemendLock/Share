public class TaskTen
{
    public static void Main(String[] args)
    {
        int CycleIncrement = 7;
        int FirstValue = 5;
        int LastValue = 96;
        
        for (int i = FirstValue; i <= LastValue; i += CycleIncrement)
        {
            Console.Write($"{i} ");
        }
    }
}
