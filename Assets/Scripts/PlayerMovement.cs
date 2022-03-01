using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    private bool isJumping;
    public bool isGrounded;
    public bool isFlipped;
    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    private Vector3 velocity = Vector3.zero;
    public float SMOOTH_TIME = 0.05f;
    public float JUMP_FORCE = 300;




    // Update is called once per frame
    void Update()
    {
        // Create a collision box between the 2 elements. If colliding, return true
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);


        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("JUMP");
            if (isGrounded)
            {
                isJumping = true;
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
            isJumping = false;
        }
    }

    void FlipPlayer(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if(_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
}
