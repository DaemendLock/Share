public class TaskFour {
    private const byte AMOUNT_OF_IMAGES_CONTAINED_IN_ROW = 3;
    private const byte IMAGES_AMOUNT = 52;

    public static void Main(String[] args) {
        byte rowAmmount = IMAGES_AMOUNT / AMOUNT_OF_IMAGES_CONTAINED_IN_ROW;
        byte imagesLeft = IMAGES_AMOUNT % AMOUNT_OF_IMAGES_CONTAINED_IN_ROW;
        
        Console.WriteLine($"Rows filled: {rowAmmount}{Environment.NewLine}Images left: {imagesLeft}");
    }
}
