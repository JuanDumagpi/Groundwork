using UnityEngine;

public class fireBall : MonoBehaviour
{
    public float speed = 4f;
    private float bulletEraser = 3;
    public int damage = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Bullet ONLY affects player and crafted items.
        playerHP player = collision.GetComponent<playerHP>();
        if (player != null)
        {
            Debug.Log("Hits");
            player.playerDamaged(damage);
            Destroy(gameObject);
        }

        craftScript craft = collision.GetComponent<craftScript>();
        if (craft != null)
        {
            Debug.Log("Hits");
            craft.craftDamage(damage);
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
