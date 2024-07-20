public class TaskEleven
{
    public static void Main(String[] args)
    {
        int firstDivider = 3;
        int secondDivider = 5;
        int maximumValue = 100;
        int iHaveNoIdeaHowToCallDivierInGauseSum = 2;

        int generatedValue = new Random().Next(maximumValue + 1);

        int addendumCount = generatedValue / firstDivider;
        int resultSum = (firstDivider * (1 + addendumCount) * addendumCount) / iHaveNoIdeaHowToCallDivierInGauseSum;
        addendumCount = generatedValue / secondDivider;
        resultSum += (secondDivider * (1 + addendumCount) * addendumCount) / iHaveNoIdeaHowToCallDivierInGauseSum;

        int leastCommonMultiple = firstDivider;

        while (leastCommonMultiple % secondDivider != 0)
        {
            leastCommonMultiple += firstDivider;
        }

        addendumCount = generatedValue / leastCommonMultiple;
        resultSum -= (leastCommonMultiple * (1 + addendumCount) * addendumCount) / iHaveNoIdeaHowToCallDivierInGauseSum;

        Console.WriteLine(generatedValue + " " + resultSum);
    }
}
