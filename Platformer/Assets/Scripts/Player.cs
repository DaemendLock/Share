using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : Entity
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce = 20;
    [Min(0.0001f), SerializeField] private float _grondDistanceToJump = 0.01f;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        _rigidbody.velocity += new Vector2(0, Mass * _jumpForce);
    }

    public void Walk(Vector2 direction)
    {
        float speed = _moveSpeed * Mass;
        _rigidbody.velocity = new Vector2(speed * direction.x, _rigidbody.velocity.y * direction.y);
    }

    public void Stop()
    {
        _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
    }

    public bool OnGround()
    {
        float sizeMultiplier = 0.5f;
        float highMultiplier = 2;

        return Physics2D.BoxCast(transform.position - new Vector3(0, transform.localScale.y * (sizeMultiplier + _grondDistanceToJump * highMultiplier), 0), new Vector2(transform.localScale.x, _grondDistanceToJump), 0, Vector2.down, transform.localScale.y * _grondDistanceToJump);
    }
}
