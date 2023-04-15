public class TaskSeven
{
    public static void Main(String[] args)
    {
        const int WaitingTimeInMinutes = 10;
        const int MinutesContainedInHour = 60;
        
        Console.WriteLine("People in queue:");
        int PeopleInQueue = Convert.ToInt32(Console.ReadLine());
        int waitingTimeInMinutes = WaitingTimeInMinutes * queueLength;
        int waitingTimeInHours = waitingTimeInMinutes / MinutesContainedInHour;

        waitingTimeInMinutes = waitingTimeInMinutes - waitingTimeInHours * MinutesContainedInHour;
        Console.WriteLine($"Estimated time in line: {waitingTimeInHours}h {waitingTimeInMinutes}m.");
    }
}
