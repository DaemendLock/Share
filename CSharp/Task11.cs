public class TaskEleven
{
    public static void Main(String[] args)
    {
        int firstDivider = 3;
        int secondDivider = 5;
        int maximumValue = 100;
        
        int generatedValue = new Random().Next(maximumValue);
        
        int addendumCount = generatedValue / firstDivider;
        int resultSum = (firstDivider * (1 + addendumCount) * addendumCount) >> 1;
        addendumCount = generatedValue / secondDivider;
        resultSum += (secondDivider * (1 + addendumCount) * addendumCount) >> 1;
        
        int lcm = firstDivider;
        
        while (lcm % secondDivider != 0)
        {
            lcm += firstDivider;
        }
        
        addendumCount = generatedValue / lcm;
        resultSum -= (lcm * (1 + addendumCount) * addendumCount) >> 1;
        
        Console.WriteLine(generatedValue + " "+resultSum);
    }
}
