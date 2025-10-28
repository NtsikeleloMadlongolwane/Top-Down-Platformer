using UnityEngine;

public class Dash : MonoBehaviour
{
    private PlayerMovemenr playerScript;

    [Header("Skins")]
    private SpriteRenderer spriteRenderer;
    public Sprite normalSprite;
    public Sprite dashSprite;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerScript = collision.GetComponent<PlayerMovemenr>();
        spriteRenderer = collision.GetComponent<SpriteRenderer>();
        playerScript.canDash = true;
        spriteRenderer.sprite = dashSprite;
    }
}
