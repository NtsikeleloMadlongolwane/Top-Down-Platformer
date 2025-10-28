using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //public GameObject cameraGameObject;
    public FollowPlayer followPlayer;
    public PlayerMovemenr playerMovemenr;
    public void Start()
    {
     // Follow();
    }

    public void ResetCheck()
    {
        playerMovemenr.HazardRespawn();
        followPlayer.ResetToLastCheckpoint();
        Debug.Log("Respawned");
    }

    public void Timed()
    {
        followPlayer.IsTimed = true;
        followPlayer.isFollowing = false;
    }
    public void Follow()
    {
        followPlayer.isFollowing = true;
        followPlayer.IsTimed = false;
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
