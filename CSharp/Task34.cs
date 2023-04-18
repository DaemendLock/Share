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

        balance += ServeLine(line);

        Console.WriteLine("No more customers. Balance: "+balance);
    }

    public static int ServeLine(Queue<int> line)
    {
        int balance = 0;

        while (line.Count > 0)
        {
            Console.WriteLine("Next bill for " + line.Peek());

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();

            balance += line.Dequeue();

            Console.WriteLine("Current balance: " + balance);
        }

        return balance;
    }
}
