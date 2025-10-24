using UnityEngine;

public class Tornado : MonoBehaviour
{
    private PlayerMovemenr playerScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerScript = collision.GetComponent<PlayerMovemenr>();
        if(playerScript != null)
        {
            playerScript.isInGeyser = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerScript = collision.GetComponent<PlayerMovemenr>();

        if (playerScript != null)
        {
            playerScript.isInGeyser = false;
        }
    }
}
