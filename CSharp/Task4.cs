public class TaskFour
{   
    public static void Main(String[] args)
    {
        byte ImagesContainedInRow = 3;
        byte ImagesCount = 52;

        byte filledRows = ImagesCount / ImagesContainedInRow;
        byte imagesLeft = ImagesCount % ImagesContainedInRow;
        
        Console.WriteLine($"Rows filled: {filledRows}{Environment.NewLine}Images left: {imagesLeft}");
    }
}
