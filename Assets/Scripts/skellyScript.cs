
using UnityEngine;

public class skellyScript : MonoBehaviour
{
    public int health;
    public int maxHealth = 2;
    public int damage = 2;
    public skellyPatrol enemyPatrol;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    //makes the crafted objects and player able to be damaged by enemies
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Craft" || collision.gameObject.tag == "Player")
        {
            drillScript drill = collision.gameObject.GetComponent<drillScript>();
            craftScript craft = collision.gameObject.GetComponent<craftScript>();
            playerHP player = collision.gameObject.GetComponent<playerHP>();
            if (craft != null)
            {
                enemyPatrol.KBTime = enemyPatrol.KBTotalTime;
                if (collision.transform.position.x <= transform.position.x)
                {
                    enemyPatrol.KBFromRight = true;
                }
                enemyPatrol.KBTime = enemyPatrol.KBTotalTime;
                if (collision.transform.position.x >= transform.position.x)
                {
                    enemyPatrol.KBFromRight = false;
                }
                craft.craftDamage(damage);
            }
            if (player != null)
            {
                enemyPatrol.KBTime = enemyPatrol.KBTotalTime;
                if (collision.transform.position.x <= transform.position.x)
                {
                    enemyPatrol.KBFromRight = true;
                }
                enemyPatrol.KBTime = enemyPatrol.KBTotalTime;
                if (collision.transform.position.x >= transform.position.x)
                {
                    enemyPatrol.KBFromRight = false;
                }
                player.playerDamaged(damage);
            }
            if (drill != null)
            {
                enemyPatrol.KBTime = enemyPatrol.KBTotalTime;
                if (drill.transform.position.x <= transform.position.x)
                {
                    enemyPatrol.KBFromRight = true;
                }
                enemyPatrol.KBTime = enemyPatrol.KBTotalTime;
                if (drill.transform.position.x >= transform.position.x)
                {
                    enemyPatrol.KBFromRight = false;
                }
                drill.craftDamage(damage);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Copper"))
        {
                Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Silver"))
        {
                Destroy(other.gameObject);
        }

    }
}
