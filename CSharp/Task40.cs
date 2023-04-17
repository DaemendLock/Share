public class TaskFourty
{
    public static void Main(string[] args)
    {
        Database database = new Database();

        int id = Player.CreatePlayerInDatabase("AAAAAA", 1, database);

        database.Ban(id);

        database.Unban(id);

        database.Remove(id);
    }

}

public class Database
{
    private List<Player> _players = new List<Player>();

    public int Add(Player player)
    {
        int result = _players.Count;
        _players.Add(player);
        return result;
    }

    public void Ban(int playerId)
    {
        if (playerId >= _players.Count || playerId < 0)
        {
            Console.Error.WriteLine("Can't find player with id " + playerId);
        }

        _players[playerId].Banned = true;
    }

    public void Unban(int playerId)
    {
        if (playerId >= _players.Count || playerId < 0)
        {
            Console.Error.WriteLine("Can't find player with id " + playerId);
        }

        _players[playerId].Banned = false;
    }

    public void Remove(int playerId)
    {
        _players.RemoveAt(playerId);
    }
}

public sealed class Player
{
    private int _id;
    private readonly string _nickname;
    private int _lvl;
    public bool Banned = false;

    private Player()
    {
        throw null;
    }

    private Player(string nickname, int lvl)
    {
        _nickname = nickname;
        _lvl = lvl;
    }

    public static int CreatePlayerInDatabase(string nickname, int lvl, Database database)
    {
        Player newPlayer = new Player(nickname, lvl);
        newPlayer._id = database.Add(newPlayer);
        return newPlayer._id;
    }
}
