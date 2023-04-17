public class TaskThirtyTwo
{
    public static void Main(String[] args)
    {
        int leftDrawPosition = 0;
        int topDrawPosition = 0;
        int fillPercent = 70;

        DrawBar(fillPercent, leftDrawPosition, topDrawPosition);
    }

    private static void DrawBar(int fillPercent, int left, int top, int barLength = 10, char fill = '#', char background = '_', char border = '|' )
    {
        int percentToValueDivider = 100;
        int percentMinValue = 0;
        int percentMaxValue = 100;

        if(fillPercent < percentMinValue || fillPercent > percentMaxValue)
        {
            Console.Error.WriteLine($"Fill percent must be in range [{percentMinValue}, {percentMaxValue}]");
            fillPercent = Math.Clamp(fillPercent, percentMinValue, percentMaxValue);
        }

        Console.SetCursorPosition(left, top);

        string fillText = new string(fill, fillPercent * barLength / percentToValueDivider);
        string backgroundText = new string(background, barLength - fillText.Length);

        Console.Write($"{border}{fillText}{backgroundText}{border}");
    }
}
