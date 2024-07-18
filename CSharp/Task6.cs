public class TaskSix
{
    public static void Main(String[] args)
    {
        int crystalCost = 10;
        
        Console.WriteLine("Amount of gold:");
        int userBalance = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Crystals required(Crystals cost is {crystalCost}):");
        int crytalRequired = Convert.ToInt32(Console.ReadLine());

        userBalance -= crytalAmountRequired * crystalCost;
        Console.WriteLine($"Gold: {userBalance}.{Environment.NewLine}Crystals: {crytalAmountRequired}.");
    }
}
