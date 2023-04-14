public class TaskSeven
{
    public static void Main(String[] args)
    {
        int WaitingTimeInMinutes = 10;
        int MinutesContainedInHour = 60;
        
        Console.WriteLine("Queue length:");
        int queueLength = Convert.ToInt32(Console.ReadLine());
        int waitingTimeInMinutes = WaitingTimeInMinutes * queueLength;
        int waitingTimeInHours = waitingTimeInMinutes / MinutesContainedInHour;

        waitingTimeInMinutes = waitingTimeInMinutes - waitingTimeInHours * MinutesContainedInHour;
        Console.WriteLine($"Estimated time in line: {waitingTimeInHours}h {waitingTimeInMinutes}m.");
    }
}
