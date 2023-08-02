using System;
using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    public event Action HealthChanged;

    [SerializeField] private float _maxHealth;
    private float _health;

    public float Health => _health;
    public float MaxHealth => _maxHealth;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(float value)
    {
        ModifyHealth(value);
    }

    private void Heal(float value)
    {
        ModifyHealth(-value);
    }
    
    private void ModifyHealth(float value)
    {
        _health = Mathf.Clamp(_health + value, 0, _maxHealth);
        HealthChanged?.Invoke();
    }
}
