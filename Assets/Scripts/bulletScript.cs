using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody2D rb;
    public int damage = 1;
    private float bulletEraser = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        
        //Bullet ONLY affects enemies.
        enemyScript enemy = collision.GetComponent<enemyScript>();
        if (enemy != null)
        {
            Debug.Log("Hits");
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }

        skellyScript skelly = collision.GetComponent<skellyScript>();
        if (skelly != null)
        {
            Debug.Log("Hits");
            skelly.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        //So that the bullets don't go on forever and despawn at a set time
        bulletEraser -= Time.deltaTime;
        if (bulletEraser <= 0)
        {
            Destroy(gameObject);
        }
    }
}
