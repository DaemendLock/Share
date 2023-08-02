using UnityEngine;

public class ModifyHealthButton : MonoBehaviour
{
    [SerializeField] private UnitHealth _target;
    [SerializeField] private float _value;

    public void ApplyAsDamage()
    {
        _target?.ModifyHealth(-_value);
    }

    public void ApplyAsHealing()
    {
        _target?.ModifyHealth(_value);
    }
}
