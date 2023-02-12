using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void OnTriggerEnter(Collider loadLevelTrigger)
    {
        if (loadLevelTrigger.gameObject.name == "DieTrigger")
        {
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                LoadLevel1();
            }
            if (SceneManager.GetActiveScene().name == "Level2")
            {
                LoadLevel2();
            }
            if (SceneManager.GetActiveScene().name == "Level3")
            {
                LoadLevel3();
            }
            if (SceneManager.GetActiveScene().name == "Level4")
            {
                LoadLevel4();
            }
            if (SceneManager.GetActiveScene().name == "Level5")
            {
                LoadLevel5();
            }
        }
        if (loadLevelTrigger.gameObject.name == "NextLevel")
        {
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                LoadLevel2();
            }
            if (SceneManager.GetActiveScene().name == "Level2")
            {
                LoadLevel3();
            }
            if (SceneManager.GetActiveScene().name == "Level3")
            {
                LoadLevel4();
            }
            if (SceneManager.GetActiveScene().name == "Level4")
            {
                LoadLevel5();
            }
        }
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadLevel4()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadLevel5()
    {
        SceneManager.LoadScene(5);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
