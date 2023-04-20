public class TaskTwentyEight
{
    public static void Main(String[] args)
    {
        const string AddCommand = "1";
        const string PrintCommand = "2";
        const string RemoveCommand = "3";
        const string FindCommand = "4";
        const string ExitCommand = "5";

        List<KeyValuePair<string, string>> files = new List<KeyValuePair<string, string>>();

        bool exitRequested = false;
        string input;

        while (exitRequested == false)
        {
            Console.WriteLine($"Write command: add - {AddCommand}, print - {PrintCommand}, remove - {RemoveCommand}, find - {FindCommand}, exit - {ExitCommand}");
            input = Console.ReadLine();

            switch (input)
            {
                case AddCommand:
                    AddFile(files);
                    break;

                case PrintCommand:
                    Print(files);
                    break;

                case RemoveCommand:
                    RemoveFile(files);
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

    private static void AddFile(List<KeyValuePair<string, string>> files)
    {
        files.Add(new (ReadNextString("Write name: "), ReadNextString("Write position: ")));
    }

    private static void RemoveFile(List<KeyValuePair<string, string>> files)
    {
        if (files.Count == 0)
        {
            Console.Error.WriteLine("0 files stored.");
            return;
        }

        Console.WriteLine("Write file index");
        int index;

        while (int.TryParse(Console.ReadLine(), out index) == false)
        {
            Console.Error.WriteLine("Can't parse index.");
        }

        files.RemoveAt(index);
    }

    private static void Print(List<KeyValuePair<string, string>> files)
    {
        if (files.Count == 0)
        {
            Console.Error.WriteLine("0 files printed.");
        }

        foreach ((string name, string position) in files)
        {
            Console.WriteLine(name + " - " + position);
        }
    }

    private static string ReadNextString(string requestMessage)
    {
        Console.WriteLine(requestMessage);
        return Console.ReadLine();
    }
}
