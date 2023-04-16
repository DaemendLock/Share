public class TaskTwelveFive {
    public static void Main(String[] args) {
        int arrayLength = 30;
        int maxRandomValue = 9;
        int[] numbers = new int[arrayLength];

        Random random = new Random();

        for (int i = 0; i < arrayLength; i++) {
            numbers[i] = random.Next(maxRandomValue + 1);
            Console.Write(numbers[i]);
        }

        int maxRepeatitions = 1;
        int maxRepeatitionsValue = numbers[0];
        int lastValue = numbers[0];
        int currentRepeatitions = 1;

        for (int i = 1; i < arrayLength; i++) {
            if (numbers[i] == lastValue) {
                currentRepeatitions++;
                continue;
            }

            if (currentRepeatitions > maxRepeatitions)
            {
                maxRepeatitionsValue = lastValue;
                maxRepeatitions = currentRepeatitions;
            }
            lastValue = numbers[i];
            currentRepeatitions = 1;
        }

        if (currentRepeatitions > maxRepeatitions) {
            maxRepeatitionsValue = lastValue;
            maxRepeatitions = currentRepeatitions;
        }

        Console.WriteLine($"{Environment.NewLine}Most repeated number - {maxRepeatitionsValue}, with repeatitions count {maxRepeatitions}");
    }
}

