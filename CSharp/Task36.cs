public class TaskTwentyEight
{
    public static void Main(String[] args)
    {
        List<KeyValuePair<string, string>> files = new List<KeyValuePair<string, string>>();

        while (TryHandleInput(files));
    }

    private static bool TryHandleInput(List<KeyValuePair<string, string>> files)
    {
        const string addCommand = "add";
        const string printCommand = "print";
        const string removeCommand = "remove";

        Console.WriteLine($"Write command: {addCommand}, {printCommand}, {removeCommand}");

        string input = Console.ReadLine();

        switch (input)
        {
            case addCommand:
                Console.WriteLine("Write name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Write position: ");
                string position = Console.ReadLine();

                Add(files, name, position);
                return true;

            case printCommand:
                Print(files);
                return true;

            case removeCommand:
                Console.WriteLine("Write index of file: ");
                int index;

                while (int.TryParse(Console.ReadLine(), out index) == false)
                {
                    Console.WriteLine("Failed to read index.");
                }

                Remove(index, files);
                return true;
        }

        return false;
    }

    private static void Add(List<KeyValuePair<string, string>> files, string name, string position)
    {
        files.Add(new KeyValuePair<string, string>(name, position));
    }

    private static void Remove(int index, List<KeyValuePair<string, string>> files)
    {
        index--;

        if (index >= files.Count || index < 0)
        {
            Console.Error.WriteLine("Can't remove by index " + (index + 1));
            return;
        }

        files.RemoveAt(index);
    }

    private static void Print(List<KeyValuePair<string, string>> files)
    {
        foreach ((string name, string position) in files)
        {
            Console.WriteLine(name + " - " + position);
        }
    }
}
