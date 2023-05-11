public class TaskEightteen
{
    public static void Main(String[] args)
    {
        string text = Console.ReadLine();
        char openBracket = '(';
        
        int balance = 0;
        int maxBalance = 0;

        foreach (char symbol in text)
        {
            if (symbol == openBracket)
            {
                balance ++;
                
                if (maxBalance < balance)
                    maxBalance = balance;
                continue;
            }

            balance--;

            if(balance < 0)
            {
                break;
            }
        }

        Console.WriteLine(balance == 0);
        
        if (balance == 0)
        {
            Console.WriteLine("Max depth: " + maxBalance);
        }
    }
}
