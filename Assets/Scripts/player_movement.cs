using Unity.Mathematics;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    private float horizontal;
    public float speed;
    public float jumpPower;
    private bool isRight = true;
    bool isGrounded = false;

    [SerializeField] private Rigidbody2D rb;

    //This is for animation
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        flip();

        //if pressing the jump key, lets you jump, holding it makes you jump higher
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2 (rb.linearVelocity.x, jumpPower);
            isGrounded = false; 
            animator.SetBool("isJumping", !isGrounded);
        }
        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
            animator.SetBool("isJumping", !isGrounded);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2 (horizontal * speed, rb.linearVelocity.y);

        //checks if the horizontal velocity is more than 0 in either direction and sets it to the xVelocity variable for the running animation
        animator.SetFloat("xVelocity", math.abs(rb.linearVelocity.x));

        animator.SetFloat("yVelocity", rb.linearVelocity.y);
    }

    //flips the sprite when turning
    private void flip()
    {
        if (isRight && horizontal < 0f || !isRight && horizontal > 0f) 
        {
            isRight = !isRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        animator.SetBool("isJumping", !isGrounded);
    }

}
