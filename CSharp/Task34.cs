public class TaskThirtyFour
{
    public static void Main(string[] args)
    {
        int queueMaxLength = 100;
        int billMaxLength = 1000;

        int balance = 0;

        Queue<int> line = new Queue<int>();

        Random random = new Random();

        for (int i = 0; i < random.Next(queueMaxLength); i++)
        {
            line.Enqueue(random.Next(billMaxLength));
        }

        while (line.Count > 0)
        {
            balance += GetNextBill(line);
            Console.WriteLine("Current balance: " + balance);
        }

        Console.WriteLine("No more customers.");
    }

    public static int GetNextBill(Queue<int> line)
    {
        int bill = line.Peek();
        Console.WriteLine("Next bill for " + bill);

        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        Console.Clear();

        line.Dequeue();
        return bill;
    }
}
