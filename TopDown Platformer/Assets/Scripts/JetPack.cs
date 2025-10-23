using UnityEngine;

public class JetPack : MonoBehaviour
{
    private PlayerMovemenr playerScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerScript = collision.GetComponent<PlayerMovemenr>();

        playerScript.hasJetPack = true;
        playerScript.jetPackPNG.SetActive(true);
    }
}
