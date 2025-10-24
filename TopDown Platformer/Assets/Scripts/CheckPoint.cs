using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private PlayerMovemenr playerScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerScript = collision.GetComponent<PlayerMovemenr>();

        playerScript.respawnPoint = new Vector3(transform.position.x, transform.position.y, 0f);
        Debug.Log(playerScript.respawnPoint);
    }
}
