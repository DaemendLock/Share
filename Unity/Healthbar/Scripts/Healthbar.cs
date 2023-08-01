using TMPro;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Bar _bar;
    [SerializeField] private TMP_Text _text;

    [Min(0.001f),SerializeField] private float _percentAdjustSpeed;

    private void Update()
    {
        _text.text = PlayerHealth.Instance.Health.ToString() + " / " + PlayerHealth.Instance.MaxHealth.ToString();

        _bar.Fill = Mathf.MoveTowards(_bar.Fill, PlayerHealth.Instance.Health / PlayerHealth.Instance.MaxHealth, _percentAdjustSpeed * Time.deltaTime);
    }
}
