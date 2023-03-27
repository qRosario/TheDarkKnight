using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float _speed = 2.0f;
    [SerializeField] private Transform _camera;
    [SerializeField] private LayerMask _notPlayer;
    [SerializeField] private Transform _groundCheker;
    private PlayerMovement _playerMovement;
    private Vector3 _movement;
    private Vector3 _moveDir;
    private bool _jump;
    private bool _isAir;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        PlayerReadInput();
        _playerMovement.Animation(_movement, _isAir);
    }

    private void FixedUpdate()
    {
        _playerMovement.Movement(_moveDir, _movement);
        _playerMovement.Jump(_jump);
    }

    private void PlayerReadInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _movement = new Vector3(horizontal, 0, vertical).normalized;
        _movement = _camera.TransformDirection(_movement);
        _moveDir = Vector3.ClampMagnitude(_movement, 1) * _speed;

        if (Physics.Raycast(_groundCheker.position, Vector3.down, 0.1f, _notPlayer))
        {
            _isAir = false;

            if (Input.GetKeyDown(KeyCode.Space) && _isAir == false)
            {
                _jump = true;
            }
        }
        else
        {
            _isAir = true;
            _jump = false;
        }
    }
}
