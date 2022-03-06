using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    private bool isJumping;
    public bool isGrounded;
    public bool isFlipped;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask collisionLayers;

    public float jumpInterval = 0.3f;
    private bool canJump = true;

    private Vector3 velocity = Vector3.zero;


    public int remainingJump;
    public int maxJumpCount;

    public float SMOOTH_TIME = 0.05f;
    public float JUMP_FORCE = 300;


    private void Start()
    {
        ResetJumpCount();
    }

    void Update()
    {
        if (canJump)
        {
            HandleJumpUpdate();
        }
    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);

        // Compute movement
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        MovePlayer(horizontalMovement);
        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);


        FlipPlayer(rb.velocity.x);
    }

    void MovePlayer(float _horizontalMovement)
    {
        if (isJumping == true)
        {
            // Reset the y axis of the velocity before jump
            rb.velocity = new Vector3(rb.velocity.x, 0f);
            rb.AddForce(new Vector2(0f, JUMP_FORCE));

            --remainingJump;

            isJumping = false;

            // Minimum interval between jumps
            // Helps to prevent resetting the number of jumps in mid-air
            StartCoroutine(setJumpInterval());
        }

        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, SMOOTH_TIME);
 
    }

    void FlipPlayer(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }


    void HandleJumpUpdate()
    {

        if (isGrounded)
        {
            ResetJumpCount();
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (remainingJump > 0)
            {
                isJumping = true;
            }
        }

    }
    void ResetJumpCount()
    {
        remainingJump = maxJumpCount;
    }

    private IEnumerator setJumpInterval()
    {
        canJump = false;
        yield return new WaitForSeconds(jumpInterval);
        canJump = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
