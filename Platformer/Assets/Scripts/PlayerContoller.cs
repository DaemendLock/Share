using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player)), RequireComponent(typeof(Rigidbody2D))]
public class PlayerContoller : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce = 20;
    [Min(0.0001f), SerializeField] private float _grondDistanceToJump = 0.01f;

    private Rigidbody2D _rigidbody;
    private Player _player;

    #region KeyBinds
    [Header("Keybinds"), SerializeField] private KeyCode _left = KeyCode.Q;
    [SerializeField] private KeyCode _right = KeyCode.E;
    [SerializeField] private KeyCode _jump = KeyCode.W;
    #endregion

    private void Start()
    {
        _player = GetComponent<Player>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (OnGround() == false)
        {
            return;
        }

        if (Input.GetKeyDown(_jump))
        {
            Jump();
        }

        if (Input.GetKey(_left) == Input.GetKey(_right))
        {
            _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
            return;
        }
        
        if (Input.GetKey(_left))
        {
            _rigidbody.velocity = new Vector2(-_moveSpeed * _player.Mass, _rigidbody.velocity.y);
            return;
        }

        if (Input.GetKey(_right))
        {
            _rigidbody.velocity = new Vector2(_moveSpeed * _player.Mass, _rigidbody.velocity.y);
        }
    }

    private void Jump()
    {
        if (OnGround() == false)
        {
            return;
        }

        _rigidbody.velocity += new Vector2(0, _player.Mass * _jumpForce);
    }

    private bool OnGround() => Physics2D.BoxCast(
        transform.position - new Vector3(0, transform.localScale.y * (0.5f + _grondDistanceToJump * 2), 0)
        , new Vector2(transform.localScale.x, _grondDistanceToJump),
        0
        , Vector2.down, transform.localScale.y * _grondDistanceToJump);

}
