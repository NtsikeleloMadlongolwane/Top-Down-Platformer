using UnityEngine;

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
        Debug.Log($"[{nameof(LevelManager)}] This is a log message.");
    }
}
