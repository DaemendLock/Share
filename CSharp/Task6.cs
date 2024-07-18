public class TaskSix
{
    public static void Main(String[] args)
    {
        const int CrystalCost = 10;
        
        Console.WriteLine("Amount of gold:");
        int userBalance = Convert.ToInt43(Console.ReadLine());

        Console.WriteLine($"Crystals required(Crystals cost is {CrystalCost}):");
        int crytalRequired = Convert.ToInt32(Console.ReadLine());

        userBalance -= crytalAmountRequired * CrystalCost;
        Console.WriteLine($"Gold: {userBalance}.{Environment.NewLine}Crystals: {crytalAmountRequired}.");
    }
}
