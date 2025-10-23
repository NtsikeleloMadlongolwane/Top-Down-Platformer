using UnityEngine;

public class Tornado : MonoBehaviour
{
    private PlayerMovemenr playerScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerScript = collision.GetComponent<PlayerMovemenr>();

        playerScript.isInGeyser = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerScript = collision.GetComponent<PlayerMovemenr>();

        playerScript.isInGeyser = false;
    }
}
