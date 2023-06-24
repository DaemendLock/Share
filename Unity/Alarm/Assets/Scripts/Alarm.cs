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

    private Coroutine _coroutine;
    private float _destination = 0;
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
        if (enabled == false)
        {
            return;
        }

        _destination = _maxThreatLevel;
        _coroutine ??= StartCoroutine(ModifyTreatLevel());
    }

    public void TurnOff()
    {
        _destination = 0;
        _coroutine ??= StartCoroutine(ModifyTreatLevel());
    }

    private IEnumerator ModifyTreatLevel()
    {
        _audioSource.Play();

        while (_threatLevel != _destination)
        {
            _threatLevel = Mathf.MoveTowards(_threatLevel, _destination, Time.deltaTime * _threatLevelIncreasePerSecond);
            _audioSource.volume = _threatLevel / _maxThreatLevel;
            yield return null;
        }

        if (_threatLevel == _maxThreatLevel)
        {
            Debug.Log("Calling police...");
        }
        else if (_threatLevel == 0)
        {
            _audioSource.Stop();
            _coroutine = null;
        }

        _coroutine = null;
    }
}
