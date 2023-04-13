public class TaskNine {
    private const byte CycleIncrement = 7;
    private const byte FirstValue = 5;
    private const byte LastValue = 96;

    public static void Main(String[] args) {
        for (byte currentValue = FirstValue; currentValue <= LastValue; currentValue += CycleIncrement) {
            Console.Write($"{currentValue} ");
        }
    }
}
