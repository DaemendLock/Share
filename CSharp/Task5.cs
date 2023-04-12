public class TaskFive {
    public static void Main(String[] args) {
        string firstName = "Daemender";
        string lastName = "Warlock";

        Console.WriteLine(firstName + " " + lastName);

        var swapBuffer = firstName;
        firstName = lastName;
        lastName = swapBuffer;
        //(firstName, lastName) = (lastName, firstName);
        Console.WriteLine(firstName + " " + lastName);
    }
}
