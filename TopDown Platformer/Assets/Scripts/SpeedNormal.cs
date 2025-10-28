using UnityEngine;

public class SpeedNormal : MonoBehaviour
{
    private PlayerMovemenr playerScript;

    [Header("Skins")]
    private SpriteRenderer spriteRenderer;
    public Sprite normalSprite;

    public float newSpeed = 5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerScript = collision.GetComponent<PlayerMovemenr>();
        spriteRenderer = collision.GetComponent<SpriteRenderer>();

        playerScript.currentspeed = playerScript.orignalspeed;
        playerScript.currentJumpingPower = playerScript.originalJumpingPower;
        spriteRenderer.sprite = normalSprite;

        playerScript.hasJetPack = false;
        playerScript.jetPackPNG.SetActive(false);

        playerScript.canWallJump = false;
    }
}
