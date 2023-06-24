using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [Min(0)]
    [SerializeField] private float _maxThreatLevel;
    [SerializeField] private float _threatLevelIncreasePerSecond;

    [SerializeField] private AlarmTrigger[] _triggers;

    private AudioSource _audioSource;

    private bool _isTriggered = false;
    private float _threatLevel = 0;

    private void Start()
    {
        foreach (AlarmTrigger trigger in _triggers)
        {
            trigger?.ConnectTo(this);
        }

        _audioSource = GetComponent<AudioSource>();
    }

    public void SetOff()
    {
        if (_isTriggered == true)
        {
            return;
        }

        if (enabled == false)
        {
            return;
        }

        _isTriggered = true;
        StopAllCoroutines();
        StartCoroutine(IncreaseTreatLevel());
    }

    public void TurnOff()
    {
        if(_isTriggered == false)
        {
            return;
        }

        _isTriggered = false;
        StopAllCoroutines();
        StartCoroutine(DecreaseThreatLevel());
    }

    private IEnumerator IncreaseTreatLevel()
    {
        _audioSource.Play();

        while (_maxThreatLevel > _threatLevel)
        {
            _threatLevel = Mathf.MoveTowards(_threatLevel, _maxThreatLevel, Time.deltaTime * _threatLevelIncreasePerSecond);
            _audioSource.volume = _threatLevel/_maxThreatLevel;
            yield return null;
        }

        Debug.Log("Calling police...");
    }

    private IEnumerator DecreaseThreatLevel()
    {
        while (_threatLevel > 0)
        {
            _threatLevel = Mathf.MoveTowards(_threatLevel, 0, Time.deltaTime * _threatLevelIncreasePerSecond);
            _audioSource.volume = _threatLevel / _maxThreatLevel;
            yield return null;
        }

        _audioSource.Stop();
    }
}
