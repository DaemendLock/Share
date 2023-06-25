using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject _unit;

    private void Start()
    {
        SpawnController.RegisterSpawner(this);
    }

    public virtual void TriggerSpawn()
    {
        if(enabled == false)
        {
            return;
        }
        
        Instantiate(_unit, transform.position, transform.rotation, transform.parent);
    }
}
