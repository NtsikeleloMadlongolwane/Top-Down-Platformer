using UnityEngine;

public class Dash : MonoBehaviour
{
    private PlayerMovemenr playerScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerScript = collision.GetComponent<PlayerMovemenr>();
        playerScript.canDash = true;
    }
}
