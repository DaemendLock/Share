using UnityEngine;

public class Entity : MonoBehaviour
{
    private const float EatMassMultiplier = 1.2f;

    [SerializeField] private float _mass = 1;

    public float Mass => _mass;

    private void Start()
    {
        SetScale(Mathf.Sqrt(_mass));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Entity entity))
        {
            if (CanEat(entity) == false)
            {
                return;
            }

            Eat(entity);
        }
    }

    public bool CanEat(Entity sizeable) =>  sizeable._mass * EatMassMultiplier <= _mass;

    public void Eat(Entity sizeable)
    {
        sizeable.gameObject.SetActive(false);
        ModifyMass(sizeable.Mass);
        Destroy(sizeable.gameObject);
    }

    public void ModifyMass(float value)
    {
        _mass += value;

        SetScale(Mathf.Sqrt(_mass));
    }

    private void SetScale(float scale)
    {
        transform.localScale = new Vector3(scale, scale, scale);
    }
}
