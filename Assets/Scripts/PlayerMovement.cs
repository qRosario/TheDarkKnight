using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    [SerializeField] private float _speed = 2.0f;
    [SerializeField] private float _rotationSpeed = 10.0f;
    [SerializeField] private float _JumpForce = 1.0f;
    [SerializeField] private LayerMask _notPlayer;
    [SerializeField] private Transform _groundCheker;
    [SerializeField] private Transform _camera;
    [SerializeField] private GameObject _audioHolder;
    private Animator _animator;
    private Rigidbody _player;
    private Vector3 _movement;
    private Vector3 _moveDir;
    private bool _jump;
    private bool _isAir;
    

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        PlayerInput();
        Animation();
    }
    private void FixedUpdate()
    {
        Movement();
        Jump();
    }


    private void Jump()
    {
        if (_jump == true)
        {
            _animator.SetTrigger("Jump");
            _player.AddForce(Vector3.up * _JumpForce, ForceMode.Impulse);
            _jump = false;
        }
    }

    private void Movement()
    {
        _player.velocity = new Vector3(_moveDir.x, _player.velocity.y, _moveDir.z);
        _player.angularVelocity = Vector3.zero;

        if (_movement.magnitude > Mathf.Abs(0.1f))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_movement), Time.deltaTime * _rotationSpeed);
        }
    }

    private void PlayerInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _movement = new Vector3(horizontal, 0, vertical).normalized;
        _movement = _camera.TransformDirection(_movement);
        _moveDir = Vector3.ClampMagnitude(_movement, 1) * _speed;

        if (Physics.Raycast(_groundCheker.position, Vector3.down, 0.2f, _notPlayer))
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
        }
    }

    private void Animation()
    {
        _animator.SetFloat("MotionSpeed", Vector3.ClampMagnitude(_movement, 1).magnitude);

        if (Physics.CheckSphere(_groundCheker.position, 0.2f, _notPlayer))
        {
            _animator.SetBool("IsAir", false);
        }
        else
        {
            _animator.SetBool("IsAir", true);
        }
    }
}
