using System.Collections;
using UnityEngine;

public class playerHP : MonoBehaviour
{
    public int maxHP = 3;
    private int currentHealth;
    private SpriteRenderer spriteRenderer;
    public healthUI healthUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHP;
        healthUI.SetMaxHearts(maxHP);

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //when getting hit by an enemy class object, run the takeDamage function
    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemyScript enemy = collision.GetComponent<enemyScript>();
        if (enemy) 
        {
            TakeDamage(enemy.damagePlayer);
        }
    }

    //updates hearts in the UI when taking damage, shows Game Over if you run out
        private void TakeDamage(int damagePlayer)
    {
        currentHealth -= damagePlayer;
        healthUI.UpdateHearts(currentHealth);
        StartCoroutine(hitFlash());
        if(currentHealth <= 0)
        {
            //Game Over!
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
