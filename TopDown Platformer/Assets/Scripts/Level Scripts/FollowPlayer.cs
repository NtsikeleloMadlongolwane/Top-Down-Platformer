using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public bool isFollowing = false;
    public float minY = 0f;


    // new checkpoint system.
    public Transform currentCheckPoint;
    public Transform finalSpot;
    public float RespawnCoolDown;
    public float RiseSpeed = 2f;
    public GameObject TimedHazards;

    public bool IsRising = false;

    public bool isStopped = false;

    private void Start()
    {
        isFollowing = true;
        currentCheckPoint = null;
    }
    void Update()
    {
        if (isFollowing)
        {
         
           // transform.position = new Vector3(53.02f, player.position.y, -10f); // level 2 follow
           if(player.transform.position.y >= minY)
            {
                transform.position = new Vector3(91.93f, player.position.y, -10f);
                TimedHazards.SetActive(false);
            }
        }
  
        //   New Checkpoint

        if (IsRising)
        {  
            // Move towards the end point
            transform.position = Vector3.MoveTowards(transform.position, finalSpot.position, RiseSpeed * Time.deltaTime);
        }

        if (isStopped)
        {
 
        }

    }

    public IEnumerator StartRise()
    {

        isFollowing = false;
        isStopped = false;
        // stop followng player and start rise;
        isFollowing = false;
        IsRising = false;
        yield return new WaitForSeconds(RespawnCoolDown);
        TimedHazards.SetActive(true);
        IsRising = true;
    }

    public void StartChase()
    {
        StartCoroutine(StartRise());
    }
    public void StopRise()
    {
        isStopped = true;
        isFollowing = false;
        // stop rising and follow player
        IsRising = false;
        TimedHazards.SetActive(false); ;
    }

    public void FollowNow()
    {
        isFollowing = true;

        IsRising = false;
        isStopped = false;
    }

    public void RespawnCam()
    {
            StopRise();
            FollowNow();
            //StartChase();
    }
}
