using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovemenr : MonoBehaviour
{

    private float horizontal;
    public float orignalspeed = 8f;
    public float originalJumpingPower = 16f;
    public float horizontalJumpForce = 8f;
    private bool isFacingRight = true;
    public bool canWallJump = false;

    [Header("Material Management")]
    public PhysicsMaterial2D[] materials;
    [SerializeField] private PhysicsMaterial2D currentMaterial;
    private Collider2D col;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;

    [Header("Special Effects")]
    // movement effects
    public float currentJumpingPower = 16f;
    public float currentspeed = 8f;

        //Attachments
    // jet pack
    public GameObject jetPackPNG;
    public bool hasJetPack = false;
    public float jetPackSpeed = 16f;

    // Enviromental
    // geyser
    public bool isInGeyser = false;
    public float geyserSpeed = 10f;

    private void Start()
    {
        col = GetComponent<Collider2D>();
        currentMaterial = materials[0];
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();

        if (canWallJump && isOnWall())
        {
            col.sharedMaterial = materials[1];
            currentMaterial = col.sharedMaterial;
        }
        else
        {
            col.sharedMaterial = materials[0];
            currentMaterial = col.sharedMaterial;
        }

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, currentJumpingPower);
        }
        if (Input.GetButtonUp("Jump") && rb.linearVelocityY > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, rb.linearVelocityY * 0.5f);
        }

        // jetcpack float
        if (Input.GetKey(KeyCode.LeftShift) && hasJetPack)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jetPackSpeed);
        }

        // jetcpack float
        if (isInGeyser)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, geyserSpeed);
        }
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * currentspeed, rb.linearVelocityY);
    }   
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private bool isOnWall()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }
    private void Flip()
    {
        if((isFacingRight && horizontal < 0f) || (!isFacingRight && horizontal > 0f))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
