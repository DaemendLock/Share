public class PlayerHealth
{
    private float _maxHealth;
    private float _health;

    static PlayerHealth()
    {
        new PlayerHealth(1000);
    }

    private PlayerHealth(float health)
    {
        _maxHealth = health;
        _health = _maxHealth;

        Instance = this;
    }

    public static PlayerHealth Instance { get; private set; }

    public float Health => _health;
    public float MaxHealth => _maxHealth;

    public void ModifyHealth(float value)
    {
        _health += value;

        if(_health < 0)
        {
            _health = 0;
            return;
        }

        if (_health > _maxHealth)
        {
            _health = _maxHealth;
            return;
        }
    }
}
