using UnityEngine;

public class Balloon : MonoBehaviour
{
    private PlayerMovemenr playerScript;
    public float jumpPower = 20f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
            playerScript = collision.GetComponent<PlayerMovemenr>();
            playerScript.BallooPop(jumpPower);
            Destroy(this.gameObject);
    }
}
