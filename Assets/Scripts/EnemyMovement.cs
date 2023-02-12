using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _moveSpot;
    private Animator _animator;
    private int _currentSpot = 0;
    private int _nextSpot = 1;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Animation();
    }

    private void FixedUpdate()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, _moveSpot[_currentSpot].position, _speed * Time.deltaTime);
        transform.LookAt(_moveSpot[_currentSpot].position);

        if (Vector3.Distance(transform.position, _moveSpot[_currentSpot].position) < 0.1f)
        {
            if (_currentSpot == _moveSpot.Length - 1)
            {
                _nextSpot = -1;
            }
            if (_currentSpot == 0)
            {
                _nextSpot = 1;
            }
            _currentSpot += _nextSpot;
        }
    }

    private void Animation()
    {
        _animator.SetFloat("Speed", _speed);
    }
}
