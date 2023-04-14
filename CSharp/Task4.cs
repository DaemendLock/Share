public class TaskFour
{
    private const byte ImagesContainedInRow = 3;
    private const byte ImagesCount = 52;

    public static void Main(String[] args)
    {
        byte filledRows = ImagesCount / ImagesContainedInRow;
        byte imagesLeft = ImagesCount % ImagesContainedInRow;
        
        Console.WriteLine($"Rows filled: {filledRows}{Environment.NewLine}Images left: {imagesLeft}");
    }
}
