using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    private PlayerMovemenr playerScript;

    [Header("Skins")]
    private SpriteRenderer spriteRenderer;
    public Sprite normalSprite;
    public Sprite speedSprite;

    public float newSpeed = 5f;
    public float newJump = 20f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerScript = collision.GetComponent<PlayerMovemenr>();
        spriteRenderer = collision.GetComponent<SpriteRenderer>();

        playerScript.currentspeed = newSpeed;
        playerScript.currentJumpingPower = newJump;
        spriteRenderer.sprite = speedSprite; 
    }
}
