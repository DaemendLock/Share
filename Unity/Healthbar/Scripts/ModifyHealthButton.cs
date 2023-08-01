using Unity.VisualScripting;
using UnityEngine;

public class ModifyHealthButton : MonoBehaviour
{
    [SerializeField] private float _modifyValue;

    public void OnButtonClick()
    {
        PlayerHealth.Instance.ModifyHealth(_modifyValue);
    }
}
