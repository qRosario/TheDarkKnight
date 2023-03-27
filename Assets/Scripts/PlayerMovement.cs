using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    [SerializeField] private float _rotationSpeed = 10.0f;
    [SerializeField] private float _JumpForce = 1.0f;
    private Animator _animator;
    private Rigidbody _player;


    private void Start()
    {
        _player = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    public void Jump(bool _jump)
    {
        if (_jump == true)
        {
            _animator.SetTrigger("Jump");
            _player.AddForce(Vector3.up * _JumpForce, ForceMode.Impulse);
        }
    }

    public void Movement(Vector3 _moveDir, Vector3 _movement)
    {
        _player.velocity = new Vector3(_moveDir.x, _player.velocity.y, _moveDir.z);
        _player.angularVelocity = Vector3.zero;

        if (_movement.magnitude > Mathf.Abs(0.1f))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_movement), Time.deltaTime * _rotationSpeed);
        }
    }


    public void Animation(Vector3 _movement, bool _isAir)
    {
        _animator.SetFloat("MotionSpeed", Vector3.ClampMagnitude(_movement, 1).magnitude);

        if (_isAir == false)
        {
            _animator.SetBool("IsAir", false);
        }
        else
        {
            _animator.SetBool("IsAir", true);
        }
    }
}
