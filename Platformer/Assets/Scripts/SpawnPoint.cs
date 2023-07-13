using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private float _unitPower = 1;

    public float UnitPower => _unitPower;
}
