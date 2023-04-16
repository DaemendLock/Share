public class TaskTwelveOne
{
    public static unsafe void Main(String[] args)
    {
        int matrixWidth = 10;
        int matrixHeight = 10;

        int randomMinValue = -10;
        int randomMaxValue = 10;


        int[,] matrix = new int[matrixHeight, matrixWidth];

        Random random = new Random();

        for (int i = 0; i < matrixHeight; i++)
        {
            for (int j = 0; j < matrixWidth; j++)
            {
                matrix[i, j] = random.Next(randomMinValue, randomMaxValue + 1);
            }
        }

        int maxValue = matrix[0, 0];

        for (int i = 0; i < matrixHeight; i++)
        {
            for (int j = 0; j < matrixWidth; j++)
            {
                if (matrix[i, j] > maxValue)
                {
                    maxValue = matrix[i, j];
                }
            }
        }

        Console.WriteLine("Max value: " + maxValue);
        Console.WriteLine();

        for (int i = 0; i < matrixHeight; i++)
        {
            for (int j = 0; j < matrixWidth; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }

            Console.WriteLine();
        }

        Console.WriteLine();

        for (int i = 0; i < matrixHeight; i++)
        {
            for (int j = 0; j < matrixWidth; j++)
            {
                if (matrix[i, j] == maxValue)
                {
                    matrix[i, j] = 0;
                }

                Console.Write(matrix[i, j] + " ");
            }

            Console.WriteLine();
        }
    }
}
