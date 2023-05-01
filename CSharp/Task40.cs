using static InputModule;

public class TaskFourty
{
    public static void Main(string[] args)
    {
        Database database = new Database();

        while (database.Work())
            ;
    }
}

public class Database
{
    private Dictionary<string, Player> _players = new Dictionary<string, Player>();

    public bool Work()
    {
        const string ExitCommand = "0";
        const string AddPlayerCommand = "1";
        const string BanPlayerCommand = "2";
        const string UnbanPlayerCommand = "3";
        const string RemoveCommand = "4";

        string commandRequestMessage = Environment.NewLine + "Write next command:" + Environment.NewLine +
            AddPlayerCommand + " - add player" + Environment.NewLine +
            BanPlayerCommand + " - ban player" + Environment.NewLine +
            UnbanPlayerCommand + " - unban player " + Environment.NewLine +
            RemoveCommand + " - remove player" + Environment.NewLine +
            ExitCommand + " - exit programm";

        string input = ReadResponse(commandRequestMessage);
        Console.Clear();

        switch (input)
        {
            case AddPlayerCommand:
                Add(ReadResponse("Write player nickname: "));
                break;

            case BanPlayerCommand:
                HandleChoose(Ban, Ban);
                break;

            case UnbanPlayerCommand:
                HandleChoose(Unban, Unban);
                break;

            case RemoveCommand:
                HandleChoose(Remove, Remove);
                break;

            case ExitCommand:
                return false;

            default:
                Console.Error.WriteLine("Failed to read input.");
                return true;
        }

        return true;
    }

    public Player Add(string nickname)
    {
        if (_players.ContainsKey(nickname))
        {
            Console.Error.WriteLine("Player with this name already exists.");
            return null;
        }

        Player result = new Player(nickname, _players.Count);
        _players.Add(nickname, result);

        return result;
    }

    private void Ban(string nickname)
    {
        Ban(FindPlayer(nickname));
    }

    private void Ban(int id)
    {
        Ban(FindPlayer(id));
    }

    private void Unban(string nickname)
    {
        Ban(FindPlayer(nickname));
    }

    private void Unban(int id)
    {
        Unban(FindPlayer(id));
    }

    private void Remove(string nickname)
    {
        Remove(FindPlayer(nickname));
    }

    private void Remove(int id)
    {
        Remove(FindPlayer(id));
    }

    private Player FindPlayer(string nickname)
    {
        if (_players.TryGetValue(nickname, out Player player))
        {
            return player;
        }

        Console.Error.WriteLine("Can't find player with name " + nickname);
        return null;
    }

    private Player FindPlayer(int id)
    {
        if (id < 0)
        {
            Console.Error.WriteLine("Can't find such id.");
            return null;
        }

        foreach (Player player in _players.Values)
        {
            if (player.Id == id)
            {
                return player;
            }
        }

        Console.Error.WriteLine("Can't find such id.");
        return null;
    }

    private void Ban(Player player)
    {
        if (player == null)
        {
            Console.Error.WriteLine("Can't remove such player.");
            return;
        }
        player.Ban();
        Console.WriteLine(player.Nickname + " banned.");
    }

    private void Unban(Player player)
    {
        if (player == null)
        {
            Console.Error.WriteLine("Can't remove such player.");
            return;
        }
        player.Unban();
        Console.WriteLine(player.Nickname + " unbanned.");
    }

    private void Remove(Player player)
    {
        if (player == null)
        {
            Console.Error.WriteLine("Can't remove such player.");
            return;
        }

        if (_players.Remove(player.Nickname) == false)
        {
            Console.Error.WriteLine("Can't remove player with name " + player.Nickname + ".");
            return;
        }

        Console.WriteLine("Player removed.");
    }

    private void HandleChoose(Action<int> option1, Action<string> option2)
    {
        const int OptionOneCase = 0;
        const int OptionTwoCase = 1;

        const string OptionOneCommand = "1";
        const string OptionTwoCommand = "2";

        switch (ReadChoose("Write lookup option: " + OptionOneCommand + " for id or " + OptionTwoCommand + " for nickname.", OptionOneCommand, OptionTwoCommand))
        {
            case OptionOneCase:
                option1.Invoke(ForceReadInt("Write id"));
                return;

            case OptionTwoCase:
                option2.Invoke(ReadResponse("Write nickname"));
                return;

            default:
                return;
        }
    }
}

public class Player
{
    public readonly string Nickname = null;

    private int _level = 1;

    public Player(string nickname, int id)
    {
        Nickname = nickname;
        Id = id;
    }

    public bool Banned { get; private set; } = false;
    public int Id { get; private set; } = -1;

    public void Ban() => Banned = true;

    public void Unban() => Banned = false;

    public override int GetHashCode()
    {
        return Nickname.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        return obj is Player player && Equals(player);
    }

    public bool Equals(Player player)
    {
        return Nickname.Equals(player.Nickname);
    }

    public override string ToString()
    {
        return $"{Id} Player {Nickname}: lvl - {_level}, status: {Banned}.";
    }
}

public static class InputModule
{
    public static string ReadResponse(string message)
    {
        Console.WriteLine(message);

        return Console.ReadLine();
    }

    public static int ForceReadInt(string message = "Write number.")
    {
        Console.WriteLine(message);

        int result;

        while (int.TryParse(Console.ReadLine(), out result) == false)
        {
            Console.Error.WriteLine("Failed to read. Try again.");
        }

        return result;
    }

    public static int ReadChoose(string message, params string[] responses)
    {
        string choice = ReadResponse(message);

        for (int i = 0; i < responses.Length; i++)
        {
            if (responses[i].Equals(choice))
            {
                return i;
            }
        }

        Console.Error.WriteLine("Failed to read choose.");
        return -1;
    }
}
