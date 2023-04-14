public class TaskSeven
{
    public static void Main(String[] args)
    {
        int WaitingTimeInMinutes = 10;
        int MinutesContainedInHour = 60;
        
        Console.WriteLine("Queue length:");
        int queueLength = Convert.ToInt32(Console.ReadLine());
        int waitingTimeInMinutes = WAITING_TIME_IN_MINUTES * queueLength;
        int waitingTimeInHours = waitingTimeInMinutes / MINUTES_CONTAINED_IN_HOUR;

        waitingTimeInMinutes = waitingTimeInMinutes - waitingTimeInHours * MINUTES_CONTAINED_IN_HOUR;
        Console.WriteLine($"Estimated time in line: {waitingTimeInHours}h {waitingTimeInMinutes}m.");
    }
}
