using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //public GameObject cameraGameObject;
    public PlayerMovemenr playerMovemenr;
    public void Start()
    {
     // Follow();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitLevel()
    {
        Application.Quit();
    }
}
