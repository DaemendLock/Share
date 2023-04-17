public class TaskThirtySeven
{
    public static void Main(string[] args)
    {
        string[] letters = { "a", "b", "c", "1" };
        string[] numbers = { "1", "2", "3", "4", };

        string[] strings = Merge(letters, numbers);

        foreach (string s in strings)
        {
            Console.WriteLine(s);
        }
    }

    public static string[] Merge(string[] array1, string[] array2){
        HashSet<string> set = new HashSet<string>(array1);

        foreach (string item in array2)
        {
            set.Add(item);
        }

        return set.ToArray();
    }
}
