using static InputModule;

public class Task48
{
    public static void Main(String[] args)
    {
        const string AddCommand = "add";
        const string RemoveCommand = "remove";
        const string SkipCommand = "skip";
        const string ExitCommand = "exit";

        Aquarium aquarium = new Aquarium(ForceReadInt("Write aquarium maximum capacity:", 0));
        AquariumOwner owner = new AquariumOwner();

        string inputMessage = "Write next command: " + Environment.NewLine +
                        AddCommand + Environment.NewLine +
                        RemoveCommand + Environment.NewLine +
                        SkipCommand + Environment.NewLine +
                        ExitCommand + Environment.NewLine;

        while (inputMessage != ExitCommand)
        {
            if (owner.Interact(aquarium, inputMessage))
            {
                Console.Clear();
                aquarium.Live();
                aquarium.Print();
            }
        }
    }
}

public class AquariumOwner
{
    public bool Interact(Aquarium aquarium, string interaction)
    {
        const string AddInterationText = "add";
        const string RemoveInterationText = "remove";
        const string SkipInterationText = "skip";

        switch (ReadResponse(interaction))
        {
            case AddInterationText:
                AddFish(aquarium);
                return true;

            case RemoveInterationText:
                RemoveFish(aquarium);
                return true;

            case SkipInterationText:
                Console.WriteLine("Fishes live happily");
                return true;

            default:
                Console.Error.WriteLine("Failed to read command");
                return false;
        }
    }

    private void AddFish(Aquarium aquarium)
    {
        aquarium.Add(new Fish(ReadResponse("Write fish name:"), ForceReadInt("Write fish maximum age:")));
    }

    private void RemoveFish(Aquarium aquarium)
    {
        aquarium.Remove(new Fish(ReadResponse("Write fish name:"), ForceReadInt("Write fish's age:")));
    }
}

public class Aquarium
{
    private HashSet<Fish> _fishes;
    private int _capacity;

    public Aquarium(int capacity)
    {
        _capacity = capacity;
        _fishes = new HashSet<Fish>(capacity);
    }

    public void Add(Fish fish)
    {
        if (_fishes.Count < _capacity)
        {
            _fishes.Add(fish);
        }
        else
        {
            Console.Error.WriteLine("Can't add fish - aquarium is full.");
        }
    }

    public void Remvoe(string name, int age)
    {
        _fishes.RemoveWhere(fish => name.Equals(fish.Name) && fish.Age == age);
    }

    public void Remove(Fish fish)
    {
        _fishes.Remove(fish);
    }

    public void Live()
    {
        foreach (Fish fish in _fishes)
        {
            if (fish.Live() == false)
            {
                _fishes.Remove(fish);
            }
        }
    }

    public void Print()
    {
        foreach (Fish fish in _fishes)
        {
            Console.WriteLine(fish);
        }
    }
}

public class Fish
{
    public Fish(string name, int maxAge)
    {
        Name = name;
        Age = 0;
        MaxAge = maxAge;
    }

    public string Name { get; }
    public int MaxAge { get; }
    public int Age { get; private set; }

    public bool Live()
    {
        if (Age == MaxAge)
        {
            Console.WriteLine(Name + " died.");
            return false;
        }

        Age++;

        return true;
    }

    public override int GetHashCode()
    {
        int coefficient = 31;
        return Name.GetHashCode() * coefficient + MaxAge;
    }

    public override bool Equals(object? obj)
    {
        return obj is Fish fish && Name.Equals(fish.Name) && fish.Age == Age;
    }

    public override string ToString()
    {
        return $"{Name} - {Age}/{MaxAge}";
    }
}

public static class InputModule
{
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

    public static int ReadChoose(string message, params string[] responses)
    {
        string choice = ReadResponse(message);

        for (int i = 0; i < responses.Length; i++)
        {
            if (responses[i].Equals(choice))
            {
                return i;
            }
        }

        Console.Error.WriteLine("Failed to read choose.");
        return -1;
    }
}
