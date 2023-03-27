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
                SceneManager.LoadScene(1);
            }
            if (SceneManager.GetActiveScene().name == "Level2")
            {
                SceneManager.LoadScene(2);
            }
            if (SceneManager.GetActiveScene().name == "Level3")
            {
                SceneManager.LoadScene(3);
            }
            if (SceneManager.GetActiveScene().name == "Level4")
            {
                SceneManager.LoadScene(4);
            }
            if (SceneManager.GetActiveScene().name == "Level5")
            {
                SceneManager.LoadScene(5);
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
}
