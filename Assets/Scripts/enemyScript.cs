using Unity.Collections;
using UnityEngine;

public class enemyScript : MonoBehaviour
{

    public int health;
    public int maxHealth = 5;
    public int damage = 1;
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
        Debug.Log("Slime is " + health);
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Craft")
        {
           craftScript craft = collision.gameObject.GetComponent<craftScript>();
            if (craft != null)
            {
                Debug.Log("slime hit wall!");
                craft.craftDamage(damage);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        playerHP player = collision.GetComponent<playerHP>();
        if (player != null)
        {
            player.playerDamaged(damage);
        }


        //craftScript craft = collision.GetComponent<craftScript>();
        //if (craft != null)
        //{
        //    Debug.Log("slime hit wall!");
        //    craft.craftDamage(damage);
        //}
    }

}