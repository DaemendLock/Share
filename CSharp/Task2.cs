public class TaskThree {
    public static void Main(String[] args) {
        Console.WriteLine("What is your name?");
        string userName = Console.ReadLine();

        Console.WriteLine("What is your zodiac?");
        string userZodiac = Console.ReadLine();

        //Cast is not required, check aswell
        Console.WriteLine("What is your age?");
        string userAge = Console.ReadLine();

        Console.WriteLine($"Hello, {userName}, you appear to be {userZodiac}, {userAge} years old. Check your horoscope for more.");
    }
}
