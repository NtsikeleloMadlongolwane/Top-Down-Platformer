using UnityEngine;
using System.Collections;

public class ChaseTrigger : MonoBehaviour
{
    public bool StartsRise = false;

    public bool isStopper = false;
    public FollowPlayer followPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (StartsRise)
            {
                followPlayer.StartChase();
            }
            else if (isStopper)
            {
                followPlayer.StopRise();
            }
            else
            {
                followPlayer.FollowNow();
            }

        }
    }
}
