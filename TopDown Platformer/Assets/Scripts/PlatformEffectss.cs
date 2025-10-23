using UnityEngine;

public class PlatformEffectss : MonoBehaviour
{
    private PlayerMovemenr playerScript;

    [Header("Skins")]
    private SpriteRenderer spriteRenderer;
    public Sprite normalSprite;
    public Sprite metalSprite;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerScript = collision.GetComponent<PlayerMovemenr>();
        spriteRenderer = collision.GetComponent<SpriteRenderer>();

        if(playerScript.canWallJump == false)
        {
            playerScript.canWallJump = true;
            spriteRenderer.sprite = metalSprite;
            Debug.Log("The player can now wall jump");
        }
        else if (playerScript.canWallJump == true)
        {
            playerScript.canWallJump = false;
            spriteRenderer.sprite = normalSprite;
            Debug.Log("The player CAN NOT wall jump");
        }
    }
}
