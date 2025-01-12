using System.Collections;
using Unity.Mathematics;
using UnityEngine;


public class player_movement : MonoBehaviour
{
    //For flipping sprite
    private float horizontal;
    public bool isRight = true;

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

    //This is for collecting items
    public Items item;
    public float itemCD = 0.5f;
    public bool collectable = true;

    //Respawn Checkpoint
    public Vector2 checkPoint;
    playerHP health;


    //this is for SFX
    public AudioSource jumpAudio;
    public AudioSource pickup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        health = GetComponent<playerHP>();
        setRespawnPoint((Vector2)transform.position);
    }



    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        flip();

        //if pressing the jump key, lets you jump, holding it makes you jump higher
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpAudio.pitch = UnityEngine.Random.Range(1.3f, 1.5f);
            jumpAudio.Play();
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

    //Changes where the respawn point is
    public void setRespawnPoint(Vector2 position)
    {
        checkPoint = position;
    }

    public void Death()
    {
        deactivateColliders();
        StartCoroutine(Respawn());
        health.currentHealth = health.maxHP;
    }

    //Respawns the character to the checkpoint
    public IEnumerator Respawn()
    {
        yield return new WaitForSeconds(0.5f);
        transform.position = (Vector3)checkPoint;
        activateColliders();
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

    public void deactivateColliders ()
    {
        foreach(Collider2D c in GetComponents<Collider2D>())
        {
            c.enabled = false;
        }
    }

    public void activateColliders()
    {
        foreach (Collider2D c in GetComponents<Collider2D>())
        {
            c.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Copper"))
        {
            if (collectable == true)
            {
                Destroy(other.gameObject);
                item.copperCount++;
                item.updateCopperAmt();
                StartCoroutine(itemCooldown());
            }
        }

        if (other.gameObject.CompareTag("Silver"))
        {
            if (collectable == true)
            {
                Destroy(other.gameObject);
                item.silverCount++;
                item.updateSilverAmt();
                StartCoroutine(itemCooldown());
            }
        }

        if (other.gameObject.CompareTag("Heart"))
        {
            if (collectable == true)
            {
                Destroy(other.gameObject);
                health.healPlayer();
                StartCoroutine(itemCooldown());
            }
        }

    }


    IEnumerator itemCooldown()
    {
        pickup.pitch = UnityEngine.Random.Range(0.8f, 1.2f);
        pickup.Play();
        collectable = false;
        yield return new WaitForSeconds(itemCD);
        collectable = true;
    }
}
