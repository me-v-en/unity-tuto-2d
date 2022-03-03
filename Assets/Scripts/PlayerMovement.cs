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

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);

        if (canJump)
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
    }
    void FixedUpdate()
    {
        // Compute movement
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        MovePlayer(horizontalMovement);
        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);


        FlipPlayer(rb.velocity.x);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, SMOOTH_TIME);

        if (isJumping == true)
        {
            rb.AddForce(new Vector2(0f, JUMP_FORCE));
            --remainingJump;
            isJumping = false;
            StartCoroutine(setJumpInterval());
        }
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
