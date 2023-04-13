public class TaskEleven {
    private const byte FirstDivider = 3;
    private const byte SecondDivider = 5;
    private const byte MaximumValue = 100;

    public static void Main(String[] args) {
        uint generatedValue = (uint) new Random().Next(MaximumValue);
        uint resultSum = CountSumForDivider(generatedValue, FirstDivider) + 
                         CountSumForDivider(generatedValue, SecondDivider) - 
                         CountSumForDivider(generatedValue, GetLCM(FirstDivider, SecondDivider));
        Console.WriteLine(generatedValue + " "+resultSum);
    }

    private static uint CountSumForDivider(uint value, uint divider) {
        uint addendumCount = value / divider;
        return (divider * (1 + addendumCount) * addendumCount) >> 1;
    }

    private static uint GetLCM(uint a, uint b) {
        uint result = a;
        while (result % b != 0)
            result += a;
        return result;
    }
}
