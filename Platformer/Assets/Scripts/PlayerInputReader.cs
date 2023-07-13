using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInputReader : MonoBehaviour
{ 
    #region KeyBinds
    [Header("Keybinds"), SerializeField] private KeyCode _left = KeyCode.Q;
    [SerializeField] private KeyCode _right = KeyCode.E;
    [SerializeField] private KeyCode _jump = KeyCode.W;
    #endregion

    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        if (_player.OnGround() == false)
        {
            return;
        }

        if (Input.GetKeyDown(_jump))
        {
            _player.Jump();
        }

        if (Input.GetKey(_left) == Input.GetKey(_right))
        {
            _player.Stop();
            return;
        }
        
        if (Input.GetKey(_left))
        {
            _player.Walk(Vector2.left);
            return;
        }

        if (Input.GetKey(_right))
        {
            _player.Walk(Vector2.right);
        }
    }
}
