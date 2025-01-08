using Unity.Collections;
using UnityEngine;

public class enemyScript : MonoBehaviour
{

    public int health;
    public int maxHealth = 5;
    public int damage = 1;
    public player_movement playerMovement;
    public EnemyPatrol enemyPatrol;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //makes the enemy be able to take damage from player
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }


    //makes the wall able to be damaged by enemies
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Craft")
        {
           craftScript craft = collision.gameObject.GetComponent<craftScript>();
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
            //Knocks back the player by setting a total time for the knockback effect
            playerMovement.KBTime = playerMovement.KBTotalTime;
            if(collision.transform.position.x <= transform.position.x) { 
                playerMovement.KBFromRight = true;
            }
            playerMovement.KBTime = playerMovement.KBTotalTime;
            if (collision.transform.position.x >= transform.position.x)
            {
                playerMovement.KBFromRight = false;
            }

            //goes into the player hp script and executes the playerDamaged function
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