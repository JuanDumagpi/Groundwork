using Unity.Mathematics;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    //For flipping sprite
    private float horizontal;
    private bool isRight = true;

    //Speed of movement
    public float speed;

    //height of Jump
    public float jumpPower;

    //checks if midair
    bool isGrounded = false;
    
    //connects to the rigidbody
    [SerializeField] private Rigidbody2D rb;

    //This is for animation
    Animator animator;


    //This is for knockbacks when hit by enemy
    public float KBStrength;
    public float KBTime;
    public float KBTotalTime;
    public bool KBFromRight;
    
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
    {   //If we're not locked in knockback animation, we can move
        if(KBTime <= 0)
        {
        //For moving
        rb.linearVelocity = new Vector2 (horizontal * speed, rb.linearVelocity.y);
        }
        else //If we're still getting knocked back...
        {
            if(KBFromRight == true)
            {
                rb.linearVelocity = new Vector2(-KBStrength, KBStrength );
            }
            if (KBFromRight == false)
            {
                rb.linearVelocity = new Vector2(KBStrength, KBStrength);
            }
            KBTime -= Time.deltaTime;
        }



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
    {   //checks if on the ground, and cancels jumping animation
        isGrounded = true;
        animator.SetBool("isJumping", !isGrounded);
    }

}
