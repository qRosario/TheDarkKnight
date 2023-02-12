using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private float _mouseSens = 1f;
    private float _xRotate;
    private float _yRotate;

    private Vector3 _offset;
    private Vector3 _position;

    private void Start()
    {
        _offset = transform.position - _player.position;
        _position = new Vector3(0, 0.2f, -0.5f);
    }

    private void Update()
    {
        MouseMove();
    }
    private void FixedUpdate()
    {
        MovementToPlayer();
    }

    private void MouseMove()
    {
        _xRotate += Input.GetAxis("Mouse X") * _mouseSens;
        _yRotate += Input.GetAxis("Mouse Y") * _mouseSens;
        _yRotate = Mathf.Clamp(_yRotate, -30, 30);

        transform.rotation = Quaternion.Euler(-_yRotate, _xRotate, 0f);
    }
    private void MovementToPlayer()
    {
        transform.position = _player.position + _offset;
        transform.position = _player.position - _player.forward + _position;
    }

}
