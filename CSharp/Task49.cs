using static Utils;

public enum Gender
{
    None,
    Male,
    Female
}

public class TaskZoo
{
    public static void Main(String[] args)
    {
        Zoo zoo = new Zoo("Local zoo");
        zoo.CreateEnclosure("Empty");

        Visitor visitor = new Visitor();
        visitor.Visit(zoo);
    }
}

public class Visitor
{
    public void Visit(Zoo zoo)
    {
        bool leave = false;
        string enclosure;
        int? choice;

        while (leave == false)
        {
            choice = ReadChoose("Choose next enclouse:", zoo.GetEnclosuresNames());
            Console.Clear();

            if (choice == null)
            {
                Console.Error.WriteLine("Failed to read choice");
                continue;
            }

            enclosure = zoo.GetEnclosuresNames()[(int) choice];

            Console.WriteLine("Press any key to read about animals in " + enclosure);
            Console.ReadKey(true);
            Console.Clear();

            zoo.VisitEnclosure(enclosure);
        }
    }
}

public class Zoo
{
    private readonly HashSet<Enclosure> _enclosures;

    public Zoo(string title)
    {
        Title = title;
        _enclosures = new HashSet<Enclosure>();

        Fill();
    }

    public string Title { get; }

    public void CreateEnclosure(string name, params Animal[] animals)
    {
        _enclosures.Add(new Enclosure(name, animals));
    }

    public string[] GetEnclosuresNames()
    {
        List<string> result = new List<string>(_enclosures.Count);

        foreach (Enclosure enclosure in _enclosures)
        {
            result.Add(enclosure.Name);
        }

        return result.ToArray();
    }

    public void VisitEnclosure(string name)
    {
        foreach (Enclosure enclosure in _enclosures)
        {
            if (enclosure.Name == name)
            {
                enclosure.Print();
                return;
            }
        }

        Console.Error.WriteLine("Can't find " + name);
    }

    private void Fill()
    {
        CreateEnclosure("Ants",
            new Animal("Ant", "Just cool ant", "No sound", Gender.Male),
            new Animal("Ant", "Just cool ant", "No sound", Gender.Male));
        CreateEnclosure("Cool snek.",
            new Animal("Snake", "Snek.", "His-s-s", Gender.Female));
        CreateEnclosure("Spiders",
            new Animal("Spider", "Spider-man, Spider-man" + Environment.NewLine + "Does whatever a spider can.", "Be-e-e-e-e-n! No!", Gender.Male));
        CreateEnclosure("Fish",
            new Animal("Tuna", "Greatest threat to kitchens.", "With technology so advanced nowdays, anyone can visit me on the moon at any time if they with.", Gender.Female));
    }
}

public class Enclosure
{
    private readonly HashSet<Animal> _animals;

    public Enclosure(string name, params Animal[] animals)
    {
        Name = name;
        _animals = new HashSet<Animal>(animals);
    }

    public string Name { get; }

    public int Count => _animals.Count;

    public void Print()
    {
        Console.WriteLine($"Enclosure \"{Name}\" contains {Count} animals:");

        Console.WriteLine(string.Join(Environment.NewLine, _animals));

        Console.WriteLine();
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        return obj is Enclosure enclosure && Name.Equals(enclosure.Name);
    }
}

public class Animal
{
    public Animal(string speciesName, string speciesDescription, string sound, Gender gender)
    {
        SpeciesName = speciesName;
        SpeciesDescription = speciesDescription;
        Sound = sound;
        Gender = gender;
    }

    public string SpeciesName { get; }
    public string SpeciesDescription { get; }
    public string Sound { get; }
    public Gender Gender { get; }

    public override string ToString()
    {
        return $"{SpeciesName}({Gender}) - Sound: {Sound}.{Environment.NewLine}Description: {SpeciesDescription}";
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj);
    }

    public override int GetHashCode()
    {
        int hashCoefficient = 31;

        return SpeciesName.GetHashCode() * hashCoefficient + (int) Gender;
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
