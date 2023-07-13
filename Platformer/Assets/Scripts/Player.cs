using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : Entity
{
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump(float jumpForce)
    {
        _rigidbody.velocity += new Vector2(0, Mass * jumpForce);
    }

    public void Walk(float speed, Vector2 direction)
    {
        _rigidbody.velocity = new Vector2(speed * direction.x, _rigidbody.velocity.y * direction.y);
    }

    public void Stop()
    {
        _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
    }

    public bool OnGround(float groundHigh)
    {
        float sizeMultiplier = 0.5f;
        float highMultiplier = 2;
        
        Physics2D.BoxCast(transform.position - new Vector3(0, transform.localScale.y * (sizeMultiplier + groundHigh * highMultiplier), 0) , new Vector2(transform.localScale.x, groundHigh), 0 , Vector2.down, transform.localScale.y * groundHigh);
    }
}
