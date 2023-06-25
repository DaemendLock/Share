using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    private static SpawnController _instance;

    [SerializeField] private float _spawnCooldown;

    private List<SpawnPoint> _spawnLocations = new List<SpawnPoint>();
    private int _spawnIndex = 0;
    private float _lastSpawnTime = 0;

    public static SpawnController Instance
    {
        get { return _instance; }
        set { _instance ??= value; }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            throw new InvalidOperationException("Unable to create instance of " + GetType().Name);
        }

        Instance = this;
    }

    private void Update()
    {
        if (_lastSpawnTime <= Time.time)
        {
            SpawnNext();
            _lastSpawnTime = Time.time + _spawnCooldown;
        }
    }

    private void OnEnable()
    {
        _lastSpawnTime = Time.time;
    }
    
    public static void RegisterSpawner(SpawnPoint location)
    {
        if (Instance == null)
        {
            Debug.LogError("Failed to register spawner - controller is not assigned");
            return;
        }

        Instance._spawnLocations.Add(location);
    }

    private void SpawnNext()
    {
        if(_spawnLocations.Count == 0)
        {
            return;
        }

        _spawnIndex %= _spawnLocations.Count;

        _spawnLocations[_spawnIndex].TriggerSpawn();
        _spawnIndex++;
    }
}
