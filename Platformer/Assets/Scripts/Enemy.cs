using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : Entity
{
    [SerializeField] private List<Waypoint> _route = new List<Waypoint>();
    [SerializeField] private int _currentWaypoint = 0;
    [SerializeField] private float _speed;

    private void Update()
    {
        if (_route.Count == 0)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, _route[_currentWaypoint].transform.position, transform.localScale.x * _speed * Time.deltaTime);

        if (transform.position == _route[_currentWaypoint].transform.position)
        {
            _currentWaypoint = (_currentWaypoint + 1) % _route.Count;
        }
    }
}
