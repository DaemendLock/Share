public class TaskTwelve
{
    public static void Main(String[] args)
    { 
        int rowToGetSum = 1;
        int columnToMultiply = 0;
        int randomMaxValue = 9;

        int matrixRowsCount = 5;
        int matrixColumnsCount = 2;

        int[, ] numbers = new int[matrixRowsCount, matrixColumnsCount];

        Random randomValuesSource = new Random();

        for (int i = 0; i < matrixRowsCount; i++)
        {
            for (int j = 0; j < matrixColumnsCount; j++)
            {
                numbers[i, j] = randomValuesSource.Next(randomMaxValue + 1);
                Console.Write(numbers[i, j] + " ");
            }

            Console.WriteLine();
        }

        int sumResult = 0;

        for (int i = 0; i < matrixColumnsCount; i++)
        {
            sumResult += numbers[rowToGetSum, i];
        }

        long multiplicationResult = 1;

        for (int i = 0; i < matrixRowsCount; i++)
        {
            multiplicationResult *= numbers[i, columnToMultiply];
        }

        Console.WriteLine($"Sum: {sumResult}, Multiplication: {multiplicationResult}");
    }
}
