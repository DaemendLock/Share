public interface ICommander
{
    Platoon GetAttacker(IEnumerable<Platoon> platoons);
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
        _country1 = new FightSide(new RandomCommander(), new List<Platoon>() { new Platoon(30, 200, 10) });

        _country2 = new FightSide(new RandomCommander(), new List<Platoon>() {
            new Platoon(100, 100, 5),
            new Platoon(10, 50, 5)
        });
    }

    public void ProcessFight()
    {
        Platoon attacker1, attacker2;

        attacker1 = _country1.GetAttacker();
        attacker2 = _country2.GetAttacker();

        while (attacker1 != null && attacker2 != null)
        {
            attacker1.Attack(attacker2);
            attacker2.Attack(attacker1);

            attacker1 = _country1.GetAttacker();
            attacker2 = _country2.GetAttacker();
        }

        DeclareVictory();
    }

    private void DeclareVictory()
    {
        if (_country1.HasSoldiers())
        {
            Console.WriteLine("Country 1 win!");
            return;
        }

        if (_country2.HasSoldiers())
        {
            Console.WriteLine("Country 2 win!");
            return;
        }

        Console.WriteLine("No soldiers left. No winner today.");
    }
}

public class FightSide
{
    private List<Platoon> _platoons;
    private ICommander _commander;

    public FightSide(ICommander commander, IEnumerable<Platoon> platoons)
    {
        _platoons = new List<Platoon>(platoons);
        _commander = commander;
    }

    public bool HasSoldiers() => GetAttacker() != null;

    public Platoon GetAttacker()
    {
        for (int i = _platoons.Count - 1; i >= 0; i--)
        {
            if (_platoons[i].HasSoldiers() == false)
            {
                _platoons.RemoveAt(i);
            }
        }
        return _commander.GetAttacker(_platoons);
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

    public void Attack(Platoon target)
    {
        if (target == null || target.HasSoldiers() == false)
        {
            return;
        }

        for (int i = 0; i < _units.Count; i++)
        {
            _units[i].Attack(target._units[i % target._units.Count]);
        }

        for (int i = target._units.Count - 1; i >= 0; i--)
        {
            if (target._units[i].IsAlive == false)
            {
                target._units.RemoveAt(i);
            }
        }
    }

    public bool HasSoldiers() => _units.Count > 0;
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
    public bool IsAlive => Health <= 0;

    public void Attack(Unit target)
    {
        if (IsAlive == false || target == null)
        {
            return;
        }

        target.Health -= Damage;
    }
}

public class RandomCommander : ICommander
{
    private Random _random;

    public RandomCommander()
    {
        _random = new Random();
    }

    public Platoon GetAttacker(IEnumerable<Platoon> platoons)
    {
        if (platoons.Count() == 0)
        {
            return null;
        }

        return platoons.ElementAt(_random.Next(platoons.Count()));
    }
}
