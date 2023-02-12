using UnityEngine;

public class Traps : MonoBehaviour
{
    [SerializeField] private float _timeToOpen = 3;
    [SerializeField] private float _timeToClose = 3;
    [SerializeField] private GameObject _floor;
    private bool _isClose;

    private void Start()
    {
        _isClose = true;
    }

    private void Update()
    {
        TrapMovement();
    }

    private void TrapMovement()
    {
        if (_isClose == true)
        {
            _timeToOpen -= Time.deltaTime;

            if (_timeToOpen <= 0)
            {
                _floor.SetActive(false);
                _timeToOpen = 3;
                _isClose = false;
            }
        }
        else if (_isClose == false)
        {
            _timeToClose -= Time.deltaTime;

            if (_timeToClose <= 0)
            {
                _floor.SetActive(true);
                _timeToClose = 3;
                _isClose = true;
            }
        }
    }
}

