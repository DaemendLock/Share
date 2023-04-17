public class TaskTwentyEight
{
    public static void Main(String[] args)
    {
        string[] names = new string[0];
        string[] positions = new string[0];

        while (TryHandleInput(ref names, ref positions));
    }

    private static bool TryHandleInput(ref string[] names, ref string[] positions)
    {
        const string addCommand = "add";
        const string printCommand = "print";
        const string removeCommand = "remove";
        const string findCommand = "find";

        Console.WriteLine($"Write command: {addCommand}, {printCommand}, {removeCommand}, {findCommand}");

        string input = Console.ReadLine();

        switch (input)
        {
            case addCommand:
                Console.WriteLine("Write name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Write position: ");
                string position = Console.ReadLine();

                Add(name, position, ref names, ref positions);
                return true;

            case printCommand:
                Print(names, positions);
                return true;

            case removeCommand:
                Console.WriteLine("Write index of file: ");
                int index;

                while (int.TryParse(Console.ReadLine(), out index) == false)
                {
                    Console.WriteLine("Failed to read index.");
                }

                Remove(index, ref names, ref positions);
                return true;

            case findCommand:
                Console.WriteLine("Write surname for lookup: ");
                string surname = Console.ReadLine();

                int foundIndex = GetIndex(surname, names);

                if (foundIndex == -1)
                {
                    Console.Error.WriteLine("Can't find this surname");
                }
                else
                {
                    Console.WriteLine($"Found {foundIndex}");
                }
                return true;
        }

        return false;
    }

    private static void Add(string name, string position, ref string[] names, ref string[] positions)
    {
        names = GetExtendedArray(names);
        positions = GetExtendedArray(positions);

        names[names.Length - 1] = name;
        positions[names.Length - 1] = position;
    }

    private static void Remove(int index, ref string[] names, ref string[] positions)
    {
        index--;

        if (index >= names.Length || index < 0)
        {
            Console.Error.WriteLine("Can't remove by index " + (index + 1));
            return;
        }

        (names[names.Length - 1], names[index]) = (names[index], names[names.Length - 1]);
        (positions[names.Length - 1], positions[index]) = (positions[index], positions[positions.Length - 1]);

        names = GetShortenArray(names);
        positions = GetShortenArray(positions);
    }

    private static void Print(string[] names, string[] positions)
    {
        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine($"{i + 1}: {names[i]}  - {positions[i]}");
        }
    }

    private static int GetIndex(string surname, string[] names)
    {
        for (int i = 0; i < names.Length; i++)
        {
            if (names[i].Contains(surname))
                return i;
        }

        return -1;
    }

    private static string[] GetExtendedArray(string[] array)
    {
        string[] result = new string[array.Length + 1];

        for (int i = 0; i < array.Length; i++)
        {
            result[i] = array[i];
        }

        return result;
    }

    private static string[] GetShortenArray(string[] array)
    {
        string[] result = new string[array.Length - 1];

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = array[i];
        }

        return result;
    }
}
