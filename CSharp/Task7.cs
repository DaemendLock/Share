public class TaskSeven
{
    public static void Main(String[] args)
    {
        int waitingTimeInMinutes = 10;
        int minutesContainedInHour = 60;
        
        Console.WriteLine("People in queue:");
        int peopleInQueue = Convert.ToInt32(Console.ReadLine());
        int waitingTimeInMinutes = waitingTimeInMinutes * peopleInQueue;
        int waitingTimeInHours = waitingTimeInMinutes / minutesContainedInHour;

        waitingTimeInMinutes = waitingTimeInMinutes - waitingTimeInHours * minutesContainedInHour;
        Console.WriteLine($"Estimated time in line: {waitingTimeInHours}h {waitingTimeInMinutes}m.");
    }
}
