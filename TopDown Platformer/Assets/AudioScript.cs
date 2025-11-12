using UnityEngine;

public class JumpSound : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioSource audioSource;   // Assign your AudioSource in the Inspector
    public AudioClip jumpSound;       // Assign your jump sound clip

    [Header("Jump Settings")]
    public KeyCode jumpKey = KeyCode.Space;  // Default jump key
    public float jumpForce = 5f;
    public bool isGrounded = true;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;

        // Play the jump sound
        if (jumpSound != null)
        {
            audioSource.PlayOneShot(jumpSound);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Simple ground check
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
