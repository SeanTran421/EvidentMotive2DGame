
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public float dashSpeed;
    public float dashDuration;
    public float dashCooldown;

    private Rigidbody2D rb;
    private bool isGrounded;

    private Animator animation;
    private bool isDashing;
    private facingDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
    }


    void Update()
    {
        float moveInput = 0f;

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            moveInput = -1f;
        }

        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            moveInput = 1f;
        }

        if ((Keyboard.current.zKey.wasPressedThisFrame || Keyboard.current.jKey.wasPressedThisFrame) && isGrounded)
        {

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        rb.linearVelocity = new Vector2(
            moveInput * moveSpeed,
            rb.linearVelocity.y
        );

        SetAnimation(moveInput);

    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void SetAnimation(float moveInput)
    {
        if (isGrounded)
        {
            if(moveInput == 0)
            {
                animation.Play("Player_Idle");
            }
            else
            {
                animation.Play("Player_Run");
            }
        }
        else
        {
            if(rb.linearVelocityY > 0 || rb.linearVelocityY < 0)
            {
                animation.Play("Player_Jump");
            }
        }
    }
}
