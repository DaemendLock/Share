using System.Collections;
using TMPro;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private UnitHealth _target;
    [SerializeField] private Bar _bar;
    [SerializeField] private TMP_Text _text;

    [Min(0.001f), SerializeField] private float _percentAdjustSpeed;

    private bool _isAdjustingHealth;

    private void OnEnable()
    {
        _target.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _target.HealthChanged += OnHealthChanged;
    }

    private void OnHealthChanged()
    {
        if (_isAdjustingHealth)
        {
            return;
        }

        StartCoroutine(Modify());
    }

    private IEnumerator Modify()
    {
        _isAdjustingHealth = true;

        while (_bar.Fill != _target.Health / _target.MaxHealth)
        {
            _text.text = _target.Health.ToString() + " / " + _target.MaxHealth.ToString();

            _bar.Fill = Mathf.MoveTowards(_bar.Fill, _target.Health / _target.MaxHealth, _percentAdjustSpeed * Time.deltaTime);
            yield return null;
        }

        _isAdjustingHealth = false;
    }
}
