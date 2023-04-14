public class TaskEleven
{
    public static void Main(String[] args)
    {
        int FirstDivider = 3;
        int SecondDivider = 5;
        int MaximumValue = 100;
        
        int generatedValue = new Random().Next(MaximumValue);
        
        int addendumCount = generatedValue / FirstDivider;
        int resultSum = (FirstDivider * (1 + addendumCount) * addendumCount) >> 1;
        addendumCount = generatedValue / SecondDivider;
        resultSum += (SecondDivider * (1 + addendumCount) * addendumCount) >> 1;
        
        int lcm = FirstDivider;
        
        while (lcm % SecondDivider != 0)
        {
            lcm += FirstDivider;
        }
        
        addendumCount = generatedValue / lcm;
        resultSum -= (lcm * (1 + addendumCount) * addendumCount) >> 1;
        
        Console.WriteLine(generatedValue + " "+resultSum);
    }
}
