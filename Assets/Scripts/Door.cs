using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject _audioHolder;
    private bool _isOpened;
    private bool _isTrigger;
    private Animator _animator;
    private AudioManager _audioManager;

    private void Start()
    {
        _audioManager = _audioHolder.GetComponent<AudioManager>();
        _animator = GetComponent<Animator>();
        _isOpened = false;
        _isTrigger = false;
    }

    private void Update()
    {
        Open();
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            _isTrigger = true;
        }
    }
    private void OnTriggerExit(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            _isTrigger = false;
        }
    }

    private void Open()
    {
        if (_isTrigger == true)
        {
            if (_isOpened == false && Input.GetKeyDown(KeyCode.R))
            {
                _audioManager.doorSound.Play();
                _animator.SetBool("IsOpened", true);
                _isOpened = true;
            }
            else if (_isOpened == true && Input.GetKeyDown(KeyCode.R))
            {
                _audioManager.doorSound.Play();
                _animator.SetBool("IsOpened", false);
                _isOpened = false;
            }
        }
    }
}
