using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TouchTrigger : AlarmTrigger
{
    private Alarm _alarm;

    public override void ConnectTo(Alarm alarm)
    {
        _alarm = alarm;
    }

    private void OnTriggerEnter2D()
    {
        _alarm?.SetOff();
    }

    private void OnTriggerExit2D()
    {
        _alarm?.TurnOff();
    }
}
