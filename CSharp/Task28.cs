public class TaskTwentyEight
{
    public static void Main(String[] args)
    {
        const string AddCommand = "1";
        const string PrintCommand = "2";
        const string RemoveCommand = "3";
        const string FindCommand = "4";
        const string ExitCommand = "5";

        string[] names = new string[0];
        string[] positions = new string[0];

        bool exitRequested = false;
        string input;

        while (exitRequested == false)
        {
            Console.WriteLine($"Write command: add - {AddCommand}, print - {PrintCommand}, remove - {RemoveCommand}, find - {FindCommand}, exit - {ExitCommand}");
            input = Console.ReadLine();

            switch (input)
            {
                case AddCommand:
                    AddFile(ref names, ref positions);
                    break;

                case PrintCommand:
                    Print(names, positions);
                    break;

                case RemoveCommand:
                    RemoveFile(ref names, ref positions);
                    break;

                case FindCommand:
                    FindByName(names, positions);
                    break;

                case ExitCommand:
                    exitRequested = true;
                    break;

                default:
                    Console.Error.WriteLine("Failed to read input.");
                    break;
            }
        }
    }

    private static void AddFile(ref string[] names, ref string[] positions)
    {
        names = ExtendArray(names, "Write name: ");
        positions = ExtendArray(positions, "Write position: ");
    }

    private static void RemoveFile(ref string[] names, ref string[] positions)
    {
        if (names.Length == 0)
        {
            Console.Error.WriteLine("0 files stored.");
        }

        Console.WriteLine("Write file index");
        int index;

        while (int.TryParse(Console.ReadLine(), out index) == false)
        {
            Console.Error.WriteLine("Can't parse index.");
        }

        index--;
        names = RemoveAt(index, names);
        positions = RemoveAt(index, positions);
    }

    private static void Print(string[] names, string[] positions)
    {
        if (names.Length== 0)
        {
            Console.Error.WriteLine("0 files printed.");
        }

        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine($"{i + 1}: {names[i]}  - {positions[i]}");
        }
    }

    private static void FindByName(string[] names, string[] positions)
    {
        if (names.Length == 0)
        {
            Console.Error.WriteLine("0 files stored.");
        }

        Console.WriteLine("Write surname for lookup: ");
        string surname = Console.ReadLine();

        int foundIndex = -1;

        for (int i = 0; i < names.Length; i++)
        {
            if (names[i].Split()[0].Equals(surname))
            {
                Console.WriteLine($"{i + 1}: {names[i]} - {positions[i]}");
                foundIndex = i;
            }
        }

        if (foundIndex == -1)
        {
            Console.Error.WriteLine("Can't find this surname");
        }
    }

    private static string[] ExtendArray(string[] array, string requestMessage)
    {
        string[] result = new string[array.Length + 1];

        Console.WriteLine(requestMessage);
        string value = Console.ReadLine();

        for (int i = 0; i < array.Length; i++)
        {
            result[i] = array[i];
        }

        result[result.Length - 1] = value;

        return result;
    }

    private static string[] RemoveAt(int index, string[] array)
    {
        if (index >= array.Length || index < 0)
        {
            Console.Error.WriteLine("Can't remove by index " + (index + 1));
            return array;
        }

        (array[array.Length - 1], array[index]) = (array[index], array[array.Length - 1]);

        string[] result = new string[array.Length - 1];

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = array[i];
        }

        return result;
    }
}
