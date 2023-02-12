using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    [SerializeField] private GameObject _door;
    [SerializeField] private GameObject _audioHolder;
    [SerializeField] private GameObject _hint;
    private bool _doorIsClose;
    private bool _inTrigger;
    private Animator _animator;
    private AudioManager _audioManager;

    private void Start()
    {
        _audioManager = _audioHolder.GetComponent<AudioManager>();
        _animator = _door.GetComponent<Animator>();
        _doorIsClose = true;
    }

    private void Update()
    {
        DoorOpen();
    }

    private void OnTriggerEnter(Collider door)
    {
        if (door.gameObject.name == "Door")
        {
            _inTrigger = true;
            _hint.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider door)
    {
        if (door.gameObject.name == "Door")
        {
            _inTrigger = false;
            _hint.SetActive(false);
        }
    }

    private void DoorOpen()
    {
        if (_inTrigger == true)
        {
            if (_doorIsClose == true && Input.GetKeyDown(KeyCode.R))
            {
                _audioManager.doorSound.Play();
                _animator.Play("DoorOpen");

                if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
                {
                    _doorIsClose = false;
                }
            }
            else if (_doorIsClose == false && Input.GetKeyDown(KeyCode.R))
            {
                _audioManager.doorSound.Play();
                _animator.Play("CloseDoor");

                if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
                {
                    _doorIsClose = true;
                }
            }
        }
    }
}
