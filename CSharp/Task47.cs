public class TaskArmy
{
    public static void Main(String[] args)
    {
        new Battlefield().ProcessFight();
    }
}

public interface IAttacker
{
    void Attack(Combatant combatant);
}

public interface ITargetOwner
{
    Unit? GetTarget(Unit unit);
}

public interface IDamagable
{
    void TakeDamage(int damage);
}

public abstract class Combatant : IAttacker, ITargetOwner
{
    public abstract void Attack(Combatant target);

    public abstract Unit? GetTarget(Unit unit);

    public abstract bool Attackable();
}

public class Battlefield
{
    private FightSide _country1;
    private FightSide _country2;

    public Battlefield()
    {
        _country1 = new FightSide(new List<Combatant>() { new Platoon(30, 200, 10) });

        _country2 = new FightSide(new List<Combatant>() {
            new Platoon(100, 100, 5),
            new Platoon(10, 50, 5)
        });
    }

    public void ProcessFight()
    {
        while (_country1.HasSoldiers() && _country2.HasSoldiers())
        {
            _country1.Attack(_country2);
            _country2.Attack(_country1);
        }

        DeclareVictory();
    }

    private void DeclareVictory()
    {
        if (_country1.HasSoldiers() == false)
        {
            Console.WriteLine("Country 2 win!");
            return;
        }

        if (_country2.HasSoldiers() == false)
        {
            Console.WriteLine("No soldiers left. No winner today.");
            return;
        }

        Console.WriteLine("Country 1 win!");
    }
}

public class FightSide : Combatant
{
    private Random _position;

    private List<Combatant> _combatants;

    public FightSide(List<Combatant> platoons)
    {
        _position = new Random();

        _combatants = platoons;
    }

    public override void Attack(Combatant target)
    {
        _combatants[_position.Next(_combatants.Count)].Attack(target);
    }

    public override bool Attackable()
    {
        return HasSoldiers();
    }

    public override Unit? GetTarget(Unit unit)
    {
        return _combatants[_position.Next(_combatants.Count)].GetTarget(unit);
    }

    public bool HasSoldiers()
    {
        foreach (Combatant combatant in _combatants)
        {
            if (combatant.Attackable())
            {
                return true;
            }
        }

        return false;
    }
}

public class Platoon : Combatant
{
    private Unit[] _units;

    public Platoon(int unitsCount, int unitHealth, int unitDamage)
    {
        _units = new Unit[unitsCount];

        for (int i = 0; i < unitsCount; i++)
        {
            _units[i] = new Unit(unitHealth, unitDamage);
        }
    }

    public override void Attack(Combatant target)
    {
        foreach (Unit unit in _units)
        {
            if (unit.Alive)
            {
                unit.Attack(target);
            }
        }
    }

    public override bool Attackable()
    {
        foreach (Unit unit in _units)
        {
            if (unit.Attackable())
            {
                return true;
            }
        }

        return false;
    }

    public override Unit? GetTarget(Unit target)
    {
        foreach (Unit unit in _units)
        {
            if (unit.Alive && unit.CanAttack(target))
            {
                return unit;
            }
        }

        return null;
    }
}

public class Unit : Combatant, IDamagable
{
    public readonly int Damage;

    public Unit(int health, int damage)
    {
        Health = health;
        Damage = damage;
        Alive = true;
    }

    public int Health { get; private set; }
    public bool Alive { get; private set; }

    public override void Attack(Combatant combatant)
    {
        if (combatant == null)
        {
            return;
        }

        combatant.GetTarget(this)?.TakeDamage(Damage);
    }

    public override Unit? GetTarget(Unit unit)
    {
        if (Alive && unit.CanAttack(this))
        {
            return this;
        }

        return null;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health < 0)
        {
            Alive = false;
        }
    }

    public bool CanAttack(Unit unit)
    {
        return true;
    }

    public override bool Attackable()
    {
        return Alive;
    }
}
