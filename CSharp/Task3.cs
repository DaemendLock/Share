public class TaskThree {
    public static void Main(String[] args) {
        Console.WriteLine("What is your name?");
        string name = Console.ReadLine();

        Console.WriteLine("What is your zodiac?");
        string zodiac = Console.ReadLine();

        Console.WriteLine("What is your age?");
        string age = Console.ReadLine();

        Console.WriteLine($"Hello, {name}, you appear to be {zodiac}, {age} years old. Check your horoscope for more.");
    }
}
