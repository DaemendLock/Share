public class TaskFive {
    public static void Main(String[] args) {
        string firstName = "String1";
        string lastName = "String2";

        Console.WriteLine(firstName + " " + lastName);

        (firstName, lastName) = (lastName, firstName);
        Console.WriteLine(firstName + " " + lastName);
    }
}
