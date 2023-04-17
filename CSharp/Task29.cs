public class Taskmap
{
    public static void Main(string[] args)
    {
        char block = '#';

        int mapWidth = 10;
        int mapHeight = 10;

        int playerStartPosition = 0;

        char[,] map = CreateMap(mapWidth, mapHeight, DateTimeOffset.UtcNow.Millisecond, block);

        int playerXPosition = playerStartPosition;
        int playerYPosition = playerStartPosition;

        bool doGameCycle = true;
        int nextPositionX;
        int nextPositionY;

        while (doGameCycle)
        {
            DrawMap(map, playerXPosition, playerYPosition);
            
            ReadNextPoition(playerXPosition, playerYPosition, out nextPositionX, out nextPositionY);
            
            if (CanMoveToPosition(nextPositionX, nextPositionY, map, block))
            {
                playerXPosition = nextPositionX;
                playerYPosition = nextPositionY;
            }
        }
    }

    private static char[,] CreateMap(int mapWidth, int mapHeight, int seed, char block)
    {
        Random random = new Random(seed);

        char[] tileLib = { '.', block };

        int mapNormalizer = 2;

        char[,] map = new char[mapHeight, mapHeight];

        for (int i = 0; i < mapHeight; i++)
        {
            for (int j = 0; j < mapWidth; j++)
            {
                map[i, j] = tileLib[random.Next(tileLib.Length * mapNormalizer) / (mapNormalizer + 1)];
            }
        }

        return map;
    }

    private static void DrawMap(char[,] map, int playerPositionX, int playerPositionY)
    {
        char player = '1';

        Console.Clear();
        Console.SetCursorPosition(0, 0);

        for (int i = 0; i < map.GetLength(1); i++)
        {
            for (int j = 0; j < map.GetLength(0); j++)
                Console.Write(map[j, i] + " ");

            Console.WriteLine();
        }

        Console.SetCursorPosition(playerPositionX * 2, playerPositionY);
        Console.Write(player);
    }

    private static bool CanMoveToPosition(int positionX, int positionY, char[,] map, char blockingValue)
    {
        return !(positionX < 0 || positionX >= map.GetLength(1) ||
            positionY < 0 || positionY >= map.GetLength(0) ||
            map[positionX, positionY] == blockingValue);
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
