using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _mainMenu;
    [SerializeField] private AudioSource _clickSound;
    [SerializeField] private AudioSource _1LevelSound;
    [SerializeField] private AudioSource _2LevelSound;
    [SerializeField] private AudioSource _3LevelSound;
    [SerializeField] private AudioSource _4LevelSound;
    [SerializeField] private AudioSource _5LevelSound;
    public AudioSource doorSound;
    private bool _soundOn;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "MenuScene")
        {
            _1LevelSound.Pause();
            _mainMenu.Play();
        }
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            _mainMenu.Pause();
            _1LevelSound.Play();
        }
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            _mainMenu.Pause();
            _2LevelSound.Play();
        }
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            _mainMenu.Pause();
            _3LevelSound.Play();
        }
        if (SceneManager.GetActiveScene().name == "Level4")
        {
            _mainMenu.Pause();
            _4LevelSound.Play();
        }
        if (SceneManager.GetActiveScene().name == "Level5")
        {
            _mainMenu.Pause();
            _5LevelSound.Play();
        }
    }

    public void OnClick()
    {
        _clickSound.Play();
    }

    public void SoundOf()
    {
        if (_soundOn == true)
        {
            _clickSound.Stop();
            AudioListener.pause = false;
            _soundOn = false;
        }
        else if (_soundOn == false)
        {
            AudioListener.pause = true;
            _soundOn = true;
        }
    }
}
