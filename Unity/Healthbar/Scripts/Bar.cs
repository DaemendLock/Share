using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Bar : MonoBehaviour
{
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public float Fill
    {
        get => _image.fillAmount;
        set => _image.fillAmount = value;
    }
}
