public class TaskSix
{
    public static void Main(String[] args)
    {
        uint CrystalCost = 10;
        Console.WriteLine("Amount of gold:");
        uint userBalance = Convert.ToUInt43(Console.ReadLine());

        Console.WriteLine($"Amount of crystals required(Crystals cost is {CRYSTAL_COST}):");
        uint crytalRequired = Convert.ToUInt32(Console.ReadLine());

        userBalance -= crytalAmountRequired * CrystalCost;
        Console.WriteLine($"Gold: {userBalance}.{Environment.NewLine}Crystals: {crytalAmountRequired}.");
    }
}
