public class TaskMap
{
    public static void Main(string[] args)
    {
        int mapWidth = 10;
        int mapHeight = 10;

        int playerStartPosition = 0;

        Console.WriteLine("Write seed or leave blank: ");
        string inputSeed = Console.ReadLine();
        int actualSeed;

        if (inputSeed == null || inputSeed.Length == 0)
        {
            actualSeed = DateTimeOffset.UtcNow.Millisecond;
        }
        else
        {
            actualSeed = inputSeed.GetHashCode();
        }

        char[,] map = CreateMap(mapWidth, mapHeight, actualSeed);

        int playerXPosition = playerStartPosition;
        int playerYPosition = playerStartPosition;

        int nextPositionX;
        int nextPositionY;

        while (true)
        {
            DrawMap(map);
            DrawPlayer(playerXPosition, playerYPosition);

            ReadNextPoition(playerXPosition, playerYPosition, out nextPositionX, out nextPositionY);

            if (CanMoveToPosition(nextPositionX, nextPositionY, map))
            {
                playerXPosition = nextPositionX;
                playerYPosition = nextPositionY;
            }
        }
    }

    private static char[,] CreateMap(int mapWidth, int mapHeight, int seed)
    {
        char block = '#';
        char path = '.';

        Random random = new Random(seed);

        char[] tileLib = { path, block };

        int blockSpawnFrequency = 2;

        char[,] map = new char[mapHeight, mapHeight];

        for (int i = 0; i < mapHeight; i++)
        {
            for (int j = 0; j < mapWidth; j++)
            {
                map[i, j] = tileLib[random.Next(tileLib.Length * blockSpawnFrequency) / (blockSpawnFrequency + 1)];
            }
        }

        return map;
    }

    private static void DrawMap(char[,] map)
    {
        Console.Clear();
        Console.SetCursorPosition(0, 0);

        for (int i = 0; i < map.GetLength(1); i++)
        {
            for (int j = 0; j < map.GetLength(0); j++)
                Console.Write(map[j, i] + " ");

            Console.WriteLine();
        }
    }

    private static void DrawPlayer(int playerPositionX, int playerPositionY)
    {
        char player = '1';

        Console.SetCursorPosition(playerPositionX * 2, playerPositionY);
        Console.Write(player);
    }

    private static bool CanMoveToPosition(int positionX, int positionY, char[,] map)
    {
        char block = '#';

        return IsPositionGenerated(positionX, positionY, map) && map[positionX, positionY] != block;
    }

    private static bool IsPositionGenerated(int positionX, int positionY, char[,] map)
    {
        bool isMovedOutOfMapWithX = positionX < 0 || positionX >= map.GetLength(1);
        bool isMovedOutOfMapWithY = positionY < 0 || positionY >= map.GetLength(0);
        
        return  !(isMovedOutOfMapWithX || isMovedOutOfMapWithY);
    }

    private static void ReadNextPoition(int currentPossitionX, int currentPossitionY, out int newPositionX, out int newPositionY)
    {
        const ConsoleKey moveLeft = ConsoleKey.Q;
        const ConsoleKey moveForward = ConsoleKey.W;
        const ConsoleKey moveRight = ConsoleKey.E;
        const ConsoleKey moveBackwards = ConsoleKey.S;

        ConsoleKey input = Console.ReadKey().Key;

        switch (input)
        {
            case moveLeft:
                newPositionY = currentPossitionY;
                newPositionX = currentPossitionX - 1;
                break;

            case moveForward:
                newPositionX = currentPossitionX;
                newPositionY = currentPossitionY - 1;
                break;

            case moveRight:
                newPositionX = currentPossitionX + 1;
                newPositionY = currentPossitionY;
                break;

            case moveBackwards:
                newPositionX = currentPossitionX;
                newPositionY = currentPossitionY + 1;
                break;
            default:
                newPositionX = currentPossitionX;
                newPositionY = currentPossitionY;
                break;
        }
    }
}
