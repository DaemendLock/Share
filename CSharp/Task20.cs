public class TaskTwelve
{
    public static unsafe void Main(String[] args)
    { 
        int sumInRow = 1;
        int multiplyInColumn = 0;

        int arrayRows = 5;
        int arrayColumns = 2;

        int[, ] array = new int[arrayRows, arrayColumns];

        Random randomValuesSource = new Random();

        for (int i = 0; i < arrayColumns; i++)
        {
            for (int j = 0; j < arrayColumns; j++)
            {
                array[i, j] = randomValuesSource.Next(10);
                Console.Write(array[i, j] + " ");
            }

            Console.Write(Environment.NewLine);
        }

        int sumResult = 0;

        for (int i = 0; i < arrayColumns; i++)
        {
            sumResult += array[sumInRow, i];
        }

        int multiplicationResult = 1;

        for (int i = 0; i < arrayRows; i++)
        {
            multiplicationResult *= array[i, multiplyInColumn];
        }

        Console.WriteLine($"Sum: {sum}, Multiplication: {multiplication}");
    }
}
