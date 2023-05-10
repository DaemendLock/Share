using static Utils;

public class Task53
{
    public static void Main(String[] args)
    {
        const int SortWithNameCommand = 0;
        const int SortWithAgeCommand = 1;
        const int FindWithDiseaseCommand = 2;
        const int ExitCommand = 3;

        string[] commands = { "sort by name", "sort by age", "find with disease", "exit" };

        List<Patient> patients = new List<Patient>()
        {
            new Patient("a", "failure", 1),
            new Patient("b", "failure", 2),
            new Patient("c", "smart", 3),
            new Patient("d", "smart", 4),
            new Patient("e", "cant breath", 1),
            new Patient("f", "cant breath", 2),
            new Patient("i", "dota", 3),
            new Patient("g", "dota", 4),
            new Patient("k", "just chilling here", 18),
            new Patient("l", "just chilling here", 19),
        };

        bool exit = false;
        IEnumerable<Patient> buffer;

        while (exit == false)
        {
            switch (ReadChoose("Write next command:", commands))
            {
                case SortWithNameCommand:
                    buffer = patients.OrderBy( patient => patient.Fullname);
                    break;

                case SortWithAgeCommand:
                    buffer = patients.OrderBy(patient => patient.BirthYear);
                    break;

                case FindWithDiseaseCommand:
                    buffer = FindWithDisease(patients);
                    break;

                case ExitCommand:
                    exit = true;
                    continue;

                default:
                    Console.Error.WriteLine("Failed to read choose");
                    continue;
            }

            Console.Clear();

            foreach (Patient patient in buffer)
            {
                Console.WriteLine(patient);
            }
        }

    }

    private static IEnumerable<Patient> FindWithDisease(IEnumerable<Patient> patients)
    {
        string lookupDisease = ReadResponse("Write disease:");

        return patients.Where(patient => patient.Disease.Equals(lookupDisease));
    }
}

public class Patient
{
    public readonly string Fullname;
    public readonly int BirthYear;

    public Patient(string fullname, string disease, int birth)
    {
        Fullname = fullname;
        BirthYear = birth;
        Disease = disease;
    }

    public string Disease { get; private set; }

    public override string ToString()
    {
        return $"Patient: {Fullname}({BirthYear}), Diseases: {Disease}";
    }
}

public static class Utils
{
    public readonly static Random Random = new Random();

    public static string ReadResponse(string message)
    {
        Console.WriteLine(message);

        return Console.ReadLine();
    }

    public static int ForceReadInt(string message = "Write number.", int minValue = int.MinValue, int maxValue = int.MaxValue)
    {
        Console.WriteLine(message);

        int result;

        while (int.TryParse(Console.ReadLine(), out result) == false || result < minValue || result >= maxValue)
        {
            Console.Error.WriteLine("Failed to read. Try again.");
        }

        return result;
    }

    public static int? ReadChoose(string message, params string[] responses)
    {
        foreach (string resposne in responses)
        {
            Console.WriteLine("-" + resposne);
        }

        string choice = ReadResponse(message);

        for (int i = 0; i < responses.Length; i++)
        {
            if (responses[i].Equals(choice, StringComparison.OrdinalIgnoreCase))
            {
                return i;
            }
        }

        Console.Error.WriteLine("Failed to read choose.");
        return null;
    }
}
