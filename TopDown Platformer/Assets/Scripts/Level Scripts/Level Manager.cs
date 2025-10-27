using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject cameraGameObject;
    public FollowPlayer followPlayer;
    public void Timed()
    {
        followPlayer.IsTimed = true;
        followPlayer.isFollowing = false;
    }
    public void Follow()
    {
        followPlayer.IsTimed = false;
        followPlayer.isFollowing = true;
    }

    void Start()
    {
        Follow();
    }
}
