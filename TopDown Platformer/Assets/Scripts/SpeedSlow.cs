using UnityEngine;

public class SpeedSlow : MonoBehaviour
{
    private PlayerMovemenr playerScript;

    [Header("Skins")]
    private SpriteRenderer spriteRenderer;
    public Sprite normalSprite;
    public Sprite slowSprite;

    public float newSpeed = 5f;
    public float newJump = 10f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerScript = collision.GetComponent<PlayerMovemenr>();
        spriteRenderer = collision.GetComponent<SpriteRenderer>();

        playerScript.currentspeed = newSpeed;
        playerScript.currentJumpingPower = newJump;
        spriteRenderer.sprite = slowSprite;
    }
}
