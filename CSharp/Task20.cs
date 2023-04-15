using System.Runtime.InteropServices;

public class TaskTwelve {
    public static unsafe void Main(String[] args)
    {
        const int ArrayRows = 5;
        const int ArrayColumns = 2;

        //Чисто по приколу
        int* array = (int*) NativeMemory.Alloc(ArrayRows * ArrayColumns * sizeof(int));

        Random randomValuesSource = new Random();

        for (int i = 0; i < ArrayRows; i++)
        {
            for (int j = 0; j < ArrayColumns; j++)
            {
                array[i * ArrayColumns + j] = randomValuesSource.Next(10);
                Console.Write(array[i * ArrayColumns + j] + " ");
            }
            
            Console.Write(Environment.NewLine);
        }

        int sum = 0;

        for (int i = ArrayColumns; i < ArrayColumns << 1; i++)
        {
            sum += array[i];
        }

        int multiplication = 1;

        for (int i = 0; i <= ArrayRows; i++)
        {
            multiplication *= array[i * ArrayColumns];
        }

        Console.WriteLine($"Sum: {sum}, Multiplication: {multiplication}");
        NativeMemory.Free(array);
    }
}
