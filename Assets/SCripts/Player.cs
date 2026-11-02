
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public float dashSpeed = 15f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;
    public AudioClip jump;
    public AudioClip dash;

    private Rigidbody2D rb;
    private bool isGrounded;

    private Animator animation;
    private bool isDashing = false;
    private float facingDirection = 1f;
    private float dashTimer = 0f;
    private float cooldownTimer = 0f;
    private Vector3 spawnPosition;
    private AudioSource audioSource;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
        spawnPosition = transform.position;
        audioSource = GetComponent<AudioSource>();
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
            audioSource.PlayOneShot(jump);
        }

        if (moveInput !=  0)
        {
            facingDirection = moveInput;
        }

        if ((Keyboard.current.xKey.wasPressedThisFrame || Keyboard.current.kKey.wasPressedThisFrame) && isDashing == false && cooldownTimer <= 0)
        {
            isDashing = true;

            rb.linearVelocity = new Vector2(
                facingDirection * dashSpeed,
                rb.linearVelocityY
            );

            audioSource.PlayOneShot(dash);

            dashTimer = dashDuration;
            cooldownTimer = dashCooldown;
        }

        if (isDashing == true)
        {
            dashTimer -= Time.deltaTime;

            if(dashTimer <= 0)
            {
                isDashing = false;
            }
        }

        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        if (isDashing == false)
        {
            rb.linearVelocity = new Vector2(
            moveInput * moveSpeed,
            rb.linearVelocity.y
            );
        }

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
    private void OnTriggerEnter2D(Collider2D other){

        if (other.CompareTag("Hazard"))
        {
            //Debug.Log("Player died!");
            transform.position = spawnPosition;
            rb.linearVelocity = Vector2.zero;
        }

        if (other.CompareTag("Finish"))
        {
            Debug.Log("Player wins!");
        }
            
    }
}

