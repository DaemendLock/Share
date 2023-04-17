public class TaskThirtyThree
{
    public static void Main(string[] args)
    {
        bool isRunning = true;
        
        Dictionary<string, string> dictionary = new Dictionary<string, string>();

        string userInput;

        while(isRunning)
        {
            Console.WriteLine("Write next word.");
            userInput = Console.ReadLine();

            if (dictionary.TryGetValue(userInput, out string meaning))
            { 
                Console.WriteLine(meaning);
                continue;
            }

            Console.WriteLine("Can't find this word. Write it's meaning");
            dictionary.Add(userInput, Console.ReadLine());
        }
    }
}
