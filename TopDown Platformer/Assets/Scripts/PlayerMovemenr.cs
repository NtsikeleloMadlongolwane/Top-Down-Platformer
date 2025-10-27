using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovemenr : MonoBehaviour
{

    private float horizontal;
    public float orignalspeed = 8f;
    public float originalJumpingPower = 16f;
    public float horizontalJumpForce = 8f;

    public float coyoteTime = 0.2f;
    public float coyoteTimeCounter;
    private bool isFacingRight = true;
    public bool canWallJump = false;

    [Header("Material Management")]
    public PhysicsMaterial2D[] materials;
    [SerializeField] private PhysicsMaterial2D currentMaterial;
    private Collider2D col;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    
    // wall slid and wall jump

    private bool isWallSliding;
    private float wallSlidingSpeed = 2f;

    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.2f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.4f;
    public Vector2 wallJumpingPower = new Vector2(8f, 16f);

    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;


    [Header("Respawn/Restart")]
    public Vector3 respawnPoint;
    public Transform currentPosition;

    [Header("Special Effects")]
        // movement effects
    // normal movement
    public float currentJumpingPower = 16f;
    public float currentspeed = 8f;
     
    [Header("Dash Settings")]
    private bool isDashing;

    public bool canDash = true;  
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dashingCoolDown = 1f;
    public TrailRenderer tr;

    //Attachments
    // jet pack
    [Header("JetPack Settings")]
    public GameObject jetPackPNG;
    public bool hasJetPack = false;
    public float jetPackSpeed = 16f;

    // Enviromental
    // geyser
    [Header("Tornado Settings")]
    public bool isInGeyser = false;
    public float geyserSpeed = 10f;

    public FollowPlayer follow;
    private void Start()
    {
        col = GetComponent<Collider2D>();
        currentMaterial = materials[0];
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        WallSlide();
        WallJump();

        if (!isWallJumping)
        {
            Flip();
        }

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

        if (isGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
        if (coyoteTimeCounter > 0 && Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, currentJumpingPower);
        }
        if (Input.GetButtonUp("Jump") && rb.linearVelocityY > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, rb.linearVelocityY * 0.5f);
            coyoteTimeCounter = 0f;
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

        // dash input
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            HazardRespawn();
        }
    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        if (!isWallJumping)
        {
            rb.linearVelocity = new Vector2(horizontal * currentspeed, rb.linearVelocityY);
        }
    }   
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private bool isOnWall()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }
    private void WallSlide()
    {
        if(isOnWall() && !isGrounded() && horizontal != 0f)
        {
            isWallSliding = true;
            rb.linearVelocity = new Vector2(rb.linearVelocityX, Mathf.Clamp(rb.linearVelocityY, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void WallJump()
    {
        if(isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if(Input.GetButton("Jump") && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            rb.linearVelocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            if(transform.localScale.x != wallJumpingDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }

            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
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

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.linearVelocity = new Vector2(transform.localScale.x * dashingPower, 0f);

        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
    }

    public void BallooPop(float balloonJumpPower)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocityX, balloonJumpPower);
    }

    public void HazardRespawn()
    {
        transform.position = respawnPoint;
        follow.ResetToLastCheckpoint();
    }
}
