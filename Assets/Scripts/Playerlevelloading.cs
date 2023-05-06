using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerlevelloading : MonoBehaviour
{
    private void OnTriggerEnter(Collider loadLevelTrigger)
    {
        if (loadLevelTrigger.CompareTag("DieTrigger"))
        {
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                Invoke("LoadScene1", 1f);
            }
            if (SceneManager.GetActiveScene().name == "Level2")
            {
                Invoke("LoadScene2", 1f);
            }
            if (SceneManager.GetActiveScene().name == "Level3")
            {
                Invoke("LoadScene3", 1f);
            }
            if (SceneManager.GetActiveScene().name == "Level4")
            {
                Invoke("LoadScene4", 1f);
            }
            if (SceneManager.GetActiveScene().name == "Level5")
            {
                Invoke("LoadScene5", 1f);
            }
        }
        if (loadLevelTrigger.CompareTag("NextLevel"))
        {
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                SceneManager.LoadScene(2);
            }
            if (SceneManager.GetActiveScene().name == "Level2")
            {
                SceneManager.LoadScene(3);
            }
            if (SceneManager.GetActiveScene().name == "Level3")
            {
                SceneManager.LoadScene(4);
            }
            if (SceneManager.GetActiveScene().name == "Level4")
            {
                SceneManager.LoadScene(5);
            }
        }

    }
    private void LoadScene1()
    {
        SceneManager.LoadScene(1);
    }
    private void LoadScene2()
    {
        SceneManager.LoadScene(2);
    }
    private void LoadScene3()
    {
        SceneManager.LoadScene(3);
    }
    private void LoadScene4()
    {
        SceneManager.LoadScene(4);
    }
    private void LoadScene5()
    {
        SceneManager.LoadScene(5);
    }
}
