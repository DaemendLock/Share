public class TaskSeven {
    private const ulong WAITING_TIME_IN_MINUTES = 10;
    private const ulong MINUTES_CONTAINED_IN_HOUR = 60;

    public static void Main(String[] args) {
        Console.WriteLine("Queue length:");
        uint queueLength = Convert.ToUInt32(Console.ReadLine());
        ulong waitingTimeInMinutes = WAITING_TIME_IN_MINUTES * queueLength;
        ulong waitingTimeInHours = waitingTimeInMinutes / MINUTES_CONTAINED_IN_HOUR;
        //Using same varriable to not allocate memory
        waitingTimeInMinutes = waitingTimeInMinutes - waitingTimeInHours * MINUTES_CONTAINED_IN_HOUR;
        Console.WriteLine($"Estimated time in line: {waitingTimeInHours}h {waitingTimeInMinutes}m.");
    }
}
