using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInputReader : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce = 20;
    [Min(0.0001f), SerializeField] private float _grondDistanceToJump = 0.01f;

    private Player _player;

    #region KeyBinds
    [Header("Keybinds"), SerializeField] private KeyCode _left = KeyCode.Q;
    [SerializeField] private KeyCode _right = KeyCode.E;
    [SerializeField] private KeyCode _jump = KeyCode.W;
    #endregion

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        if (_player.OnGround(_grondDistanceToJump) == false)
        {
            return;
        }

        if (Input.GetKeyDown(_jump))
        {
            _player.Jump(_jumpForce);
        }

        if (Input.GetKey(_left) == Input.GetKey(_right))
        {
            _player.Stop();
            return;
        }
        
        if (Input.GetKey(_left))
        {
            _player.Walk(_moveSpeed * _player.Mass, Vector2.left);
            return;
        }

        if (Input.GetKey(_right))
        {
            _player.Walk(_moveSpeed * _player.Mass, Vector2.right);
        }
    }
}
