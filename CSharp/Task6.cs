public class TaskSix {
    private const ulong CrystalCost = 10;

    public static void Main(String[] args) {
        Console.WriteLine("Amount of gold:");
        ulong userBalance = Convert.ToUInt64(Console.ReadLine());

        Console.WriteLine($"Amount of crystals required(Crystals cost is {CRYSTAL_COST}):");
        ulong crytalRequired = Convert.ToUInt64(Console.ReadLine());

        userBalance -= crytalAmountRequired * CRYSTAL_COST;
        Console.WriteLine($"Gold: {userBalance}.{Environment.NewLine}Crystals: {crytalAmountRequired}.");
    }
}
