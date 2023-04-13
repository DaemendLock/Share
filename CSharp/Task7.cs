public class TaskSeven {
    private const ulong WaitingTimeInMinutes = 10;
    private const ulong MinutesContainedInHour = 60;

    public static void Main(String[] args) {
        Console.WriteLine("Queue length:");
        uint queueLength = Convert.ToUInt32(Console.ReadLine());
        ulong waitingTimeInMinutes = WAITING_TIME_IN_MINUTES * queueLength;
        ulong waitingTimeInHours = waitingTimeInMinutes / MINUTES_CONTAINED_IN_HOUR;

        waitingTimeInMinutes = waitingTimeInMinutes - waitingTimeInHours * MINUTES_CONTAINED_IN_HOUR;
        Console.WriteLine($"Estimated time in line: {waitingTimeInHours}h {waitingTimeInMinutes}m.");
    }
}
