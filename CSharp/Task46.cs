using static InputModule;

public class TaskFourtySix
{
    public static void Main(string[] args)
    {
        TrainMaker maker = new TrainMaker( new int[]{ 10, 20 });

        bool work = true;
        Route route;

        while (work)
        {
            Console.Clear();
            Console.WriteLine("No route");
            route = maker.CreateNewRoute();

            Console.Clear();
            Console.WriteLine(route);

            int passengers = ForceReadInt("Write passengers count:", 0);
            maker.AssignTrain(route, passengers);

            Console.WriteLine(Environment.NewLine+"Press any key to departure...");
            Console.ReadKey();
        }
    }
}

public class TrainMaker
{
    private readonly int[] _carriagesCapacity = null;

    public TrainMaker(int[] carriagesCapacity)
    {
        _carriagesCapacity = carriagesCapacity;
        _carriagesCapacity.OrderDescending();
    }

    public Route CreateNewRoute()
    {
        return new Route(ReadResponse("Write departure location:"), ReadResponse("Write destination:"), ForceReadInt("Write departure time:", 0));
    }

    public void AssignTrain(Route assignTo, int passengersCount)
    {
        Train train = new Train();

        int currentCapacity = 0;

        do
        {
            foreach (int capacity in _carriagesCapacity)
            {
                if (currentCapacity + capacity >= passengersCount)
                {
                    continue;
                }

                train.AddCarriage(new Carriage(capacity));
                currentCapacity += capacity;
            }
        } while (currentCapacity + _carriagesCapacity.Last() < passengersCount);

        train.AddCarriage(new Carriage(_carriagesCapacity.Last()));

        assignTo.AssignTrain(train);
    }
}

public class Route
{
    public readonly string From = "";
    public readonly string To = "";
    public long DepartureTime { get; private set; } = 0;

    private Train _train = new Train();

    public Route(string from, string to, long departureTime)
    {
        From = from;
        To = to;
        DepartureTime = departureTime;
    }

    public void AssignTrain(Train train)
    {
        _train = new Train();
    }

    public override string ToString()
    {
        return $"Train departure at {DepartureTime}: {From} -> {To}";
    }
}

public class Train
{
    public int Passsengers { get; private set; } = 0;

    private LinkedList<Carriage> _carriages = new LinkedList<Carriage>();

    public int EvaluateMaxCapacity()
    {
        int capacity = 0;

        foreach (Carriage carriage in _carriages)
        {
            capacity += carriage.Capacity;
        }

        return capacity;
    }

    public void AddCarriage(Carriage carriage)
    {
        _carriages.AddLast(carriage);
    }
}

public class Carriage
{
    public readonly int Capacity;

    public Carriage(int capacity)
    {
        Capacity = capacity;
    }
}

public static class InputModule
{
    public static string ReadResponse(string message)
    {
        Console.WriteLine(message);

#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
        return Console.ReadLine();
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
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
