public class TaskSeven
{
    public static void Main(String[] args)
    {
        ulong WaitingTimeInMinutes = 10;
        ulong MinutesContainedInHour = 60;
        
        Console.WriteLine("Queue length:");
        uint queueLength = Convert.ToUInt32(Console.ReadLine());
        ulong waitingTimeInMinutes = WAITING_TIME_IN_MINUTES * queueLength;
        ulong waitingTimeInHours = waitingTimeInMinutes / MINUTES_CONTAINED_IN_HOUR;

        waitingTimeInMinutes = waitingTimeInMinutes - waitingTimeInHours * MINUTES_CONTAINED_IN_HOUR;
        Console.WriteLine($"Estimated time in line: {waitingTimeInHours}h {waitingTimeInMinutes}m.");
    }
}
