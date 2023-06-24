using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject _unit;

    private void Start()
    {
        SpawnController.RegisterSpawner(this);
    }

    public void TriggerSpawn()
    {
        Instantiate(_unit, transform.position, transform.rotation, transform.parent);
    }
}
