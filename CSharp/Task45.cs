using static Arena;
using static InputModule;

public class TaskArena
{
    public static void Main(string[] args)
    {

        const string FightCommand = "fight";
        const string ExitCommand = "exit";

        const string InputRequestMessage = "Write \"" + FightCommand + "\" to start new fight or \"" + ExitCommand + "\"" + "to leave";

        string userInput;

        ArenaBarker manager = new ArenaBarker();

        do
        {
            userInput = ReadResponse(InputRequestMessage);
            switch (userInput)
            {
                case FightCommand:
                    manager.SetupFight();
                    break;

                case ExitCommand:
                    continue;

                default:
                    Console.Error.WriteLine("Failed to read input");
                    break;
            }
        } while (ExitCommand.Equals(userInput) == false);

    }
}

public class ArenaBarker
{
    private const string WarriorCommand = "1";
    private const string PaladinCommand = "2";
    private const string HunterCommand = "3";
    private const string PriestCommand = "4";
    private const string MageCommand = "5";
    private const string WarlockCommand = "6";

    public void SetupFight()
    {
        Console.Clear();

        Console.WriteLine("Contestants:" +
            "\nWarrior - " + WarriorCommand +
            "\nPaladin - " + PaladinCommand +
            "\nHunter - " + HunterCommand +
            "\nPriest - " + PriestCommand +
            "\nMage - " + MageCommand +
            "\nWarlock - " + WarlockCommand);

        Fighter fighter1 = GetFighter();
        Fighter fighter2 = GetFighter();

        StartFight(fighter1, fighter2);
    }

    public Fighter GetFighter()
    {
        Fighter result = null;
        string userInput;

        do
        {
            userInput = ReadResponse("Choose contestant!");

            switch (userInput)
            {
                case WarriorCommand:
                    result = new Warrior();
                    break;

                case PaladinCommand:
                    result = new Paladin();
                    break;

                case HunterCommand:
                    result = new Hunter();
                    break;

                case PriestCommand:
                    result = new Priest();
                    break;

                case MageCommand:
                    result = new Mage();
                    break;

                case WarlockCommand:
                    result = new Warlock();
                    break;

                default:
                    Console.WriteLine("Can't hear! Who did you ask for?");
                    break;
            }
        } while (result == null);

        return result;
    }
}

public static class Arena
{
    private const int PercentDivier = 100;

    public enum Team
    {
        None = 0,
        Team1,
        Team2,
    }

    public static int Time { get; private set; }
    public static event Action<int> Tick;

    private static List<Fighter> _team1 = new List<Fighter>(1);
    private static List<Fighter> _team2 = new List<Fighter>(1);

    public static bool ArenaOccuped = false;

    public static void StartFight(Fighter fighter1, Fighter fighter2)
    {
        if (ArenaOccuped)
        {
            return;
        }

        fighter1.ChangeTeam(Team.Team1);
        _team1 = new List<Fighter>() { fighter1 };
        fighter2.ChangeTeam(Team.Team2);
        _team2 = new List<Fighter>() { fighter2 };

        ProccessFight();
    }

    public static void ProccessFight()
    {
        ArenaOccuped = true;

        while (_team1[0].Alive && _team2[0].Alive)
        {
            Update();
        }

        if (_team1[0].Alive == false)
        {
            if (_team2[0].Alive == false)
            {
                Logger.InformDraw();
            }
            else
                Logger.InformVictory(_team2[0]);
        }
        else
        {
            Logger.InformVictory(_team1[0]);
        }

        Arena.Clear();
        ArenaOccuped = false;
    }

    public static void Clear()
    {
        foreach (Fighter fighter in _team2)
        {
            fighter.Dispose();
        }

        foreach (Fighter fighter in _team1)
        {
            fighter.Dispose();
        }

        _team1 = new List<Fighter>(1);
        _team2 = new List<Fighter>(1);


    }

    public static void Update()
    {
        Time++;
        Tick?.Invoke(1);
    }

    public static void PerformeAttack(Fighter attacker, Fighter victim)
    {
        ApplyDamage(attacker, victim, attacker.Attack);
    }

    public static void ApplyDamage(Fighter attacker, Fighter victim, int originalDamage, bool evadable = true, bool ability = false)
    {
        DamageEvent damageEvent = new DamageEvent(attacker, victim, originalDamage, evadable, ability);

        damageEvent.Damage *= damageEvent.Attacker.GetDamageDealthPercent(damageEvent) / PercentDivier * damageEvent.Victim.GetDamageRecivePercent(damageEvent) / PercentDivier;

        damageEvent.Victim.TakeDamage(damageEvent);

        if (damageEvent.Damage > 0)
        {
            damageEvent.Attacker.OnDamageDealth(damageEvent);
        }
    }

    public static Fighter GetOponentOf(Fighter fighter)
    {
        if (fighter.Team == Team.Team1)
        {
            return _team2[0];
        }
        if (fighter.Team == Team.Team2)
        {
            return _team1[0];
        }

        return (Time % 2 == 0 ? _team1 : _team2)[0];
    }
}

public abstract class Object : IDisposable
{
    public Object()
    {
        Tick += Update;
    }

    public void Dispose()
    {
        Tick -= Update;
    }

    protected abstract void Update(int deltaTime);
}

public class Resource
{
    public readonly int MaxValue;
    public int Value { get; private set; }
    public int Regeneration { get; private set; }

    public Resource(int maxValue, int startValue, int regeneraion)
    {
        MaxValue = maxValue;
        Value = startValue;
        Regeneration = regeneraion;
    }

    public void ChangeValue(int value)
    {
        Value += value;
        if (Value > MaxValue)
        {
            Value = MaxValue;
        }

        if (Value < 0)
        {
            Value = 0;
        }
    }
}

public abstract class Fighter : Object
{
    public const int DefaultDamageRecivePercent = 100;

    private readonly Resource HealthPool = null;
    private readonly Resource ManaPool = null;

    public bool Alive { get; private set; } = true;

    public Team Team { get; private set; } = Team.None;

    public int Attack { get; private set; } = 0;

    private List<Ability> _abilities = new List<Ability>();

    public Fighter(int maxHealth, int maxMana, int attackDamage, int manaStartValue = 0, int healthRegen = 0, int manaRegen = 0)
    {
        _abilities = new List<Ability>();

        Alive = true;

        HealthPool = new Resource(maxHealth, maxHealth, healthRegen);
        ManaPool = new Resource(maxMana, manaStartValue, manaRegen);

        Attack = attackDamage;
    }

    public int Mana => ManaPool.Value;
    public int Health => HealthPool.Value;

    public int MaxMana => ManaPool.MaxValue;
    public int MaxHealth => HealthPool.MaxValue;

    protected override void Update(int time)
    {
        HealthPool.ChangeValue(HealthPool.Regeneration);
        ManaPool.ChangeValue(ManaPool.Regeneration);
    }

    public void ChangeTeam(Team newTeam)
    {
        Team = newTeam;
    }

    public void GiveAbility(Ability ability)
    {
        _abilities.Add(ability);
    }

    public void TakeDamage(DamageEvent e)
    {
        if (e.Damage < 0)
            return;

        HealthPool.ChangeValue(-e.Damage);

        OnDamageRecive(e);
        Logger.InformDamage(e);

        if (Health == 0)
        {
            Logger.InformDeath(this);
            OnReciveLethalDamage(e);
        }

        if (Health <= 0)
        {
            Alive = false;
        }
    }

    public void Heal(int healing)
    {
        HealthPool.ChangeValue(healing);
    }

    public void GiveMana(int value)
    {
        if (value < 0)
            return;
        ManaPool.ChangeValue(value);
    }

    public void SpendMana(int value)
    {
        if (value < 0)
            return;
        ManaPool.ChangeValue(-value);
    }

    public void CastAbilities()
    {
        foreach (Ability ability in _abilities)
        {
            if (ability.CooldownReady)
                ability.Cast();
        }
    }

    public virtual int GetDamageRecivePercent(DamageEvent e)
    {
        return DefaultDamageRecivePercent;
    }

    public virtual int GetDamageDealthPercent(DamageEvent e)
    {
        return DefaultDamageRecivePercent;
    }

    public virtual void OnReciveLethalDamage(DamageEvent e)
    {
    }

    public virtual void OnDamageDealth(DamageEvent e)
    {
    }

    public virtual void OnDamageRecive(DamageEvent e)
    {
    }
}

public class Ability
{
    public readonly string Name;
    public readonly Fighter Owner;

    public int Cooldown { get; private set; }
    public int Cost { get; private set; }

    public int CooldownEnd { get; private set; }

    public Ability(Fighter owner, string name, int cooldown, int manaCost)
    {
        Owner = owner;

        Name = name;

        Cooldown = cooldown;
        CooldownEnd = 0;

        Cost = manaCost;
    }

    public bool CooldownReady => CooldownEnd <= Time;

    public void Cast()
    {
        if (Owner.Mana < Cost)
            return;

        Logger.InformCast(this);
        CooldownEnd = Cooldown + Time;
        Owner.SpendMana(Cost);
        OnSpellStart();
    }

    public Fighter GetOwnerTarget()
    {
        return GetOponentOf(Owner);
    }

    protected virtual void OnSpellStart()
    {
    }
}

public sealed class Warrior : Fighter
{
    public Warrior() : base(1000, 10, 50, 0, 10)
    {
    }

    protected override void Update(int time)
    {
        base.Update(time);
        PerformeAttack(this, GetOponentOf(this));
    }
}

public sealed class Paladin : Fighter
{
    private int _abilityCasyHealthLevel = 300;

    public Paladin() : base(800, 20, 35, 20, 3, 1)
    {
        GiveAbility(new LieOfHand(this));
    }

    protected override void Update(int time)
    {
        base.Update(time);
        if (Health < _abilityCasyHealthLevel)
        {
            CastAbilities();
        }
        else
        {
            PerformeAttack(this, GetOponentOf(this));
        }
    }
}

public sealed class Hunter : Fighter
{
    public Hunter() : base(500, 0, 40, 0, 3)
    {
        GiveAbility(new Powershot(this));
    }

    protected override void Update(int time)
    {
        base.Update(time);
        CastAbilities();
        PerformeAttack(this, GetOponentOf(this));
    }
}

public sealed class Priest : Fighter
{
    public Priest() : base(300, 40, 30, 40, 2)
    {
        GiveAbility(new Pray(this));
    }

    protected override void Update(int time)
    {
        base.Update(time);

        if (Health < MaxHealth)
            CastAbilities();
        else
            PerformeAttack(this, GetOponentOf(this));
    }
}

public sealed class Mage : Fighter
{
    public Mage() : base(300, 40, 0, 40, 0, 4)
    {
        GiveAbility(new Fireball(this));
    }
    protected override void Update(int time)
    {
        base.Update(time);
        CastAbilities();
    }
}

public sealed class Warlock : Fighter
{
    public Warlock() : base(700, 10, 70, 10, 1, 2)
    {
        GiveAbility(new Soulstone(this));
    }

    protected override void Update(int time)
    {
        base.Update(time);

        PerformeAttack(this, GetOponentOf(this));
    }

    public override void OnReciveLethalDamage(DamageEvent e)
    {
        CastAbilities();
    }
}

public sealed class LieOfHand : Ability
{
    public LieOfHand(Fighter owner) : base(owner, "Lie of hands", 10, 0)
    {
    }

    protected override void OnSpellStart()
    {
        Owner.Heal(Owner.MaxHealth);
    }
}

public sealed class Powershot : Ability
{
    private int _damage = 10;

    public Powershot(Fighter owner) : base(owner, "Powershot", 4, 0)
    {
    }

    protected override void OnSpellStart()
    {
        ApplyDamage(Owner, GetOwnerTarget(), _damage, ability: true);
    }
}

public sealed class Pray : Ability
{
    private int _healing;

    public Pray(Fighter owner) : base(owner, "Pray", 2, 4)
    {
    }

    protected override void OnSpellStart()
    {
        Owner.Heal(100);
    }
}

public sealed class Fireball : Ability
{
    private int _damage = 100;

    public Fireball(Fighter owner) : base(owner, "Fireball", 0, 5)
    {
    }

    protected override void OnSpellStart()
    {
        ApplyDamage(Owner, GetOwnerTarget(), _damage, true, true);
    }
}

public sealed class Soulstone : Ability
{
    private int _healing = 500;

    public Soulstone(Fighter owner) : base(owner, "Soulstone", 10, 0)
    {
    }

    protected override void OnSpellStart()
    {
        Owner.Heal(_healing);
    }
}

public static class Logger
{
    public static void InformCast(Ability ability)
    {
        Console.WriteLine($"{ability.Owner} casted {ability}!");
    }

    public static void InformDamage(DamageEvent e)
    {
        Console.WriteLine($"{e.Attacker} attacked {e.Victim}: -{e.Damage}HP ({e.Victim.Health} left)");
    }

    public static void InformDeath(Fighter victim)
    {
        Console.WriteLine(victim + " died.");
    }

    public static void InformVictory(Fighter winner)
    {
        Console.WriteLine(winner + " won!");
    }

    public static void InformDraw()
    {
        Console.WriteLine("Draw!");
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

public struct DamageEvent
{
    public readonly Fighter Attacker;
    public readonly Fighter Victim;
    public readonly int OriginalDamage;
    public readonly bool Ability;
    public readonly bool Evadable;
    public int Damage;

    public DamageEvent(Fighter attacker, Fighter victim, int originalDamage, bool evadable = true, bool ability = false)
    {
        Attacker = attacker;
        Victim = victim;
        OriginalDamage = originalDamage;
        Damage = originalDamage;
        Evadable = evadable;
        Ability = ability;
    }
}
