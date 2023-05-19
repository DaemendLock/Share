public interface ICommander
{
    bool TryGetAttacker(List<Platoon> platoons, out Platoon result);
}

public class TaskArmy
{
    public static void Main(String[] args)
    {
        new Battlefield().ProcessFight();
    }
}

public class Battlefield
{
    private FightSide _country1;
    private FightSide _country2;

    public Battlefield()
    {
        _country1 = new FightSide(new RandomCommander(), new List<Platoon>() { new Platoon(30, 200, 10) }, "Country 1");

        _country2 = new FightSide(new RandomCommander(), new List<Platoon>() {
            new Platoon(100, 100, 5),
            new Platoon(10, 50, 5)
        }, "Country 2");
    }

    public void ProcessFight()
    {
        while (_country1.TryGetAttacker(out Platoon attacker1) && _country1.TryGetAttacker(out Platoon attacker2))
        {
            attacker1.Attack(attacker2);
            attacker2.Attack(attacker1);

            _country1.ClearDead();
            _country2.ClearDead();
        }

        DeclareVictory();
    }

    private void DeclareVictory()
    {
        if (_country1.HasSoldiers)
        {
            Console.WriteLine(_country1.Name + " win!");
            return;
        }

        if (_country2.HasSoldiers)
        {
            Console.WriteLine(_country2.Name + " win!");
            return;
        }

        Console.WriteLine("No soldiers left. No winner today.");
    }
}

public class FightSide
{
    private List<Platoon> _platoons;
    private ICommander _commander;

    public FightSide(ICommander commander, IEnumerable<Platoon> platoons, string name)
    {
        _platoons = new List<Platoon>(platoons);
        _commander = commander;

        Name = name;
    }

    public string Name { get; }

    public bool HasSoldiers => _platoons.Count > 0;

    public bool TryGetAttacker(out Platoon result) => _commander.TryGetAttacker(_platoons, out result);

    public void ClearDead()
    {
        _platoons.RemoveAll(platoon => platoon.HasSoldiers == false);
    }
}

public class Platoon
{
    private List<Unit> _units;

    public Platoon(int unitCount, int unitHealth, int unitDamage)
    {
        _units = new List<Unit>(unitCount);

        while (_units.Count < unitCount)
        {
            _units.Add(new Unit(unitHealth, unitDamage));
        }
    }
    public bool HasSoldiers => _units.Count > 0;

    public void Attack(Platoon target)
    {
        if (target.HasSoldiers == false)
        {
            return;
        }

        for (int i = 0; i < _units.Count; i++)
        {
            _units[i].Attack(target._units[i % target._units.Count]);
        }

        target.ClearDead();
    }

    private void ClearDead()
    {
        _units.RemoveAll(unit => unit.IsAlive == false);
    }
}

public class Unit
{
    public Unit(int health, int damage)
    {
        Damage = damage;
        Health = health;
    }

    public int Damage { get; }
    public int Health { get; private set; }
    public bool IsAlive => Health > 0;

    public void Attack(Unit target)
    {
        if (IsAlive == false)
        {
            return;
        }

        target.Health -= Damage;
    }
}

public class RandomCommander : ICommander
{
    private static Random _random = new Random();

    public bool TryGetAttacker(List<Platoon> platoons, out Platoon result)
    {
        if (platoons.Count == 0)
        {
            result = null;
            return false;
        }

        result = platoons.ElementAt(_random.Next(platoons.Count));
        return true;
    }
}
