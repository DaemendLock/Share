using UnityEngine;

public class ModifyHealthButton : MonoBehaviour
{
    [SerializeField] private UnitHealth _target;
    [SerializeField] private float _value;

    public void ApplyAsDamage()
    {
        _target?.TakeDamage(_value);
    }

    public void ApplyAsHealing()
    {
        _target?.Heal(_value);
    }
}
