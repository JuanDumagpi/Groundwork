using System.Collections;
using Unity.Collections;
using UnityEngine;

public class rangedEnemyScript : MonoBehaviour
{

    public int health;
    public int maxHealth = 2;
    public int damage = 1;
    public player_movement playerMovement;
    public lizardScript lizard;
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
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


    public IEnumerator attackAnim()
    {
        animator.SetBool("isAttacking", true);
        yield return new WaitForSeconds(1);
        lizard.lizFire();
        animator.SetBool("isAttacking", false);
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