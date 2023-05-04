using static InputModule;
using System.Linq;

public class TaskFourtySix
{
    public static void Main(string[] args)
    {
        TrainFactory maker = new TrainFactory(new int[] { 10, 20 });

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

            Console.WriteLine(Environment.NewLine + "Press any key to departure...");
            Console.ReadKey();
        }
    }
}

public class TrainFactory
{
    private readonly int[] _carriagesCapacity = null;

    public TrainFactory(int[] carriagesCapacity)
    {
        _carriagesCapacity = carriagesCapacity;
#if NET7_0_OR_GREATER
        _carriagesCapacity.OrderDescending();
#endif
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
        Console.WriteLine("Maximum passangers on this route: " + assignTo.EvaluateMaxTickets());

        assignTo.AssignTrain(train);

    }
}

public class Route
{
    public readonly string Departure = "";
    public readonly string Destination = "";

    private Train _train = new Train();

    public Route(string from, string to, long departureTime)
    {
        Departure = from;
        Destination = to;
        DepartureTime = departureTime;
    }
    public long DepartureTime { get; private set; } = 0;

    public void AssignTrain(Train train)
    {
        _train = train;
    }

    public int EvaluateMaxTickets()
    {
        return _train.EvaluateMaxCapacity();
    }

    public override string ToString()
    {
        return $"Train departure at {DepartureTime}: {Departure} -> {Destination}.";
    }
}

public class Train
{
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
