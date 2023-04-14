public class TaskFour
{   
    public static void Main(String[] args)
    {
        int ImagesContainedInRow = 3;
        int ImagesCount = 52;

        int filledRows = ImagesCount / ImagesContainedInRow;
        int imagesLeft = ImagesCount % ImagesContainedInRow;
        
        Console.WriteLine($"Rows filled: {filledRows}{Environment.NewLine}Images left: {imagesLeft}");
    }
}
