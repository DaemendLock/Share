public class TaskFifteen
{
    public unsafe static void Main(String[] args)
    {
        string Password = "123456";
        string secretMessage = "No secrets here";
        int AttempsAvaible = 3;

        int attemptsLeft = AttempsAvaible;

        while (attemptsLeft != 0) 
        {
            Console.WriteLine("Password:");

            if (Console.ReadLine().Equals(Password))
            {
                Console.WriteLine(secretMessage);
                break;
            }

            attemptsLeft -= 1;
            Console.WriteLine($"Wrong password. {attemptsLeft} attempts left");
        }
    }
}
