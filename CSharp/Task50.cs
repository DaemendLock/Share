public struct Part
{
    public readonly int Id;
    public readonly int Price;

    public Part(int id, int price = 0)
    {
        Id = id;
        Price = price;
    }

    public override int GetHashCode()
    {
        return Id;
    }

    public override bool Equals(object? obj)
    {
        return obj is Part part && Equals(part);
    }

    public bool Equals(Part part)
    {
        return Id == part.Id;
    }

    public override string ToString()
    {
        return "Part: Id - " + Id;
    }
}

public class TaskCarService
{
    public static void Main(String[] args)
    {
        int maxCars = 100;

        CarService service = new CarService(100, 1000);
        service.AddDefaultParts();
        service.QueueCars(Utils.Random.Next(maxCars));

        service.Work();
    }
}

public class Car
{
    private readonly List<Part> _parts;
    private readonly LinkedList<Part> _brokenPart;

    public Car()
    {
        _parts = new List<Part>() { new Part(0), new Part(1), new Part(2), new Part(3) };
        _brokenPart = new LinkedList<Part>();

        _brokenPart.AddLast(_parts[Utils.Random.Next(_parts.Count)]);
    }

    public Part[] GetBrokenParts()
    {
        return _brokenPart.ToArray();
    }

    public void FixPart(Part part)
    {
        _brokenPart.Remove(part);
    }
}

public class CarService
{
    private readonly Storage _storage;
    private readonly Queue<Car> _repairQueue;

    private int _blance;
    private int _repairPrice;

    public CarService(int repairPrice, int startingBalance)
    {
        _storage = new Storage();
        _repairQueue = new Queue<Car>();

        _blance = startingBalance;
        _repairPrice = repairPrice;
    }

    public void QueueCars(int count)
    {
        while (count > 0)
        {
            _repairQueue.Enqueue(new Car());
            count--;
        }
    }

    public void Work()
    {
        Car car;

        while (_repairQueue.Count > 0)
        {
            car = _repairQueue.Dequeue();
            Console.WriteLine("Next car. Broken parts:");

            foreach (Part part in car.GetBrokenParts())
            {
                Console.WriteLine(part);
            }

            Console.WriteLine(Repair(car) + "$ - repairment bill.");

            Console.WriteLine("Current balance: " + _blance);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
        }

        Console.WriteLine("Car service finished work. Balance: "+_blance);
    }

    public void AddDefaultParts()
    {
        _storage.Add(new Part(0, 50), 10);
        _storage.Add(new Part(1, 100), 10);
        _storage.Add(new Part(2, 200), 40);
        _storage.Add(new Part(3, 400), 40);
    }

    private int Repair(Car car)
    {
        Part[] repair = car.GetBrokenParts();

        int bill = 0;

        foreach (Part part in repair)
        {
            Console.Write(part);

            Part? replacement = _storage.Take(part);

            if (replacement == null)
            {
                bill -= _repairPrice;
                Console.WriteLine(" -> Can't fix - no replacement in stock.");
                continue;
            }

            car.FixPart((Part) replacement);
            Console.WriteLine(" -> Replaced.");
            bill += _repairPrice + ((Part) replacement).Price;
        }

        _blance += bill;
        return bill;
    }
}

public class Storage
{
    private readonly Dictionary<Part, int> _partsCount;
    private readonly HashSet<Part> _parts;

    public Storage()
    {
        _parts = new HashSet<Part>();
        _partsCount = new Dictionary<Part, int>();
    }

    public void Add(Part part, int count = 1)
    {
        _parts.Add(part);
        _partsCount[part] = _partsCount.GetValueOrDefault(part, 0) + count;
    }

    public Part? Take(int id)
    {
        if (_parts.Contains(new Part(id)))
        {
            return Take(new Part(id));
        }

        return null;
    }

    public Part? Take(Part part)
    {
        if (_parts.Contains(part) == false || _partsCount[part] == 0)
        {
            return null;
        }

        _partsCount[part] -= 1;
        _parts.TryGetValue(part, out Part result);
        return result;
    }

    public int GetPartsLeft(int id)
    {
        return _partsCount[new Part(id)] -= 1;
    }

    public int GetPartsLeft(Part part)
    {
        return _partsCount[part];
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
