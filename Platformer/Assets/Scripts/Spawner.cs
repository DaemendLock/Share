using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnCooldown;
    [SerializeField] private Enemy _spawnObject;
    [SerializeField] private SpawnPoint[] _spawnLocations;
    
    private int _spawnIndex = 0;

    private void OnEnable()
    {
        StartCoroutine(SpawnCycle());
    }

    private void OnDisable()
    {
        StopCoroutine(SpawnCycle());
    }

    private IEnumerator SpawnCycle()
    {
        while (enabled)
        {
            SpawnNext();
            yield return new WaitForSeconds(_spawnCooldown);
        }
    }

    private void SpawnNext()
    {
        SpawnPoint position = FindNextSpawnpoint();

        if (position == null)
        {
            return;
        }

        Transform spawnPosition = position.transform;
        Enemy enemy = Instantiate(_spawnObject, spawnPosition.position, spawnPosition.rotation, transform.parent);

        enemy.ModifyMass(position.UnitPower);
    }

    private SpawnPoint FindNextSpawnpoint()
    {
        if (_spawnLocations.Length == 0)
        {
            return null;
        }

        for (int i = 1; i < _spawnLocations.Length; i++)
        {
            if (_spawnLocations[(_spawnIndex + i) % _spawnLocations.Length].enabled)
            {
                _spawnIndex = (_spawnIndex + i) % _spawnLocations.Length;
                return _spawnLocations[_spawnIndex];
            }
        }

        return null;
    }
}
