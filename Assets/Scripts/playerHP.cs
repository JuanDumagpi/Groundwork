using System;
using System.Collections;
using UnityEngine;

public class playerHP : MonoBehaviour
{
    public int maxHP = 4;
    public int currentHealth;
    private SpriteRenderer spriteRenderer;
    public healthUI healthUI;
    internal static object currenthealth;
    public player_movement player;

    //for game over
    public int lives = 3;
    public static event Action OnPlayerDied;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHP;
        healthUI.SetMaxHearts(maxHP);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //when getting hit by an enemy class object, run the takeDamage function
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    enemyScript enemy = collision.GetComponent<enemyScript>();
    //    if (enemy) 
    //    {
    //        playerDamaged(enemy.damagePlayer);
    //    }
    //}

    //updates hearts in the UI when taking damage, shows Game Over if you run out
        public void playerDamaged(int damage)
    {
        currentHealth -= damage;
        healthUI.UpdateHearts(currentHealth);
        StartCoroutine(hitFlash());
        Debug.Log("player takes damage");
        if(currentHealth == 0)
        {
            
            if(lives <= 0)
            {
                OnPlayerDied.Invoke();
            }
            else
            {
                player.Death();
                healthUI.UpdateHearts(currentHealth);
                lives--;
            }
        }
    }

    private IEnumerator hitFlash()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.clear;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }    

    // Update is called once per frame
    void Update()
    {
        
    }
}
