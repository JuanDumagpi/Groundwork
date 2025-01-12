using UnityEngine;


public class EnemyPatrol : MonoBehaviour
{
    public Rigidbody2D rb;

    //for movement
    public float speed;
    //for flipping
    private bool isLeft = true;

    //for ledge detection
    public Transform ledgeDetect;
    public LayerMask groundLayer;
    public float raycast;
    public float raycast2;

    //This is for knockbacks when hitting a craft object
    public float KBStrength;
    public float KBTime;
    public float KBTotalTime;
    public bool KBFromRight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Physics2D.IgnoreLayerCollision(6, 6);
    }

    private void changeDirection()
    {
        isLeft = !isLeft;
        transform.Rotate(0, -180, 0);
    }

    private void Update()
    {   //draws an imaginary line from the ledgedetector empty object downwards, to check if there is a no ground layer below
        RaycastHit2D hit = Physics2D.Raycast(ledgeDetect.position, Vector2.down, raycast, groundLayer);
        RaycastHit2D hitTile = Physics2D.Raycast(ledgeDetect.position, Vector2.left, raycast2, groundLayer);
        if (hit.collider == null || hitTile.collider != null)
        {
            changeDirection();
        }
    }

    void FixedUpdate()
    {
        if (KBTime <= 0)
        {
            //movesForward and changes direction when isLeft is no longer true
            if (isLeft)
            {
                rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
            }
            else
            {
                rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
            }
        }
        else //If we're still getting knocked back...
        {
            if (KBFromRight == true)
            {
                rb.linearVelocity = new Vector2(KBStrength, rb.linearVelocity.y);
            }
            if (KBFromRight == false)
            {
                rb.linearVelocity = new Vector2(-KBStrength, rb.linearVelocity.y);
            }
            KBTime -= Time.deltaTime;
        }

    }
}
