using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class playerHP : MonoBehaviour
{
    public int maxHP = 4;
    public int currentHealth;
    private SpriteRenderer spriteRenderer;
    public healthUI healthUI;
    internal static object currenthealth;
    public player_movement player;

    
    public AudioSource hitAudio;

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
            hitAudio.pitch = UnityEngine.Random.Range(1f, 2f);
            hitAudio.Play();
            currentHealth -= damage;
            healthUI.UpdateHearts(currentHealth);
            StartCoroutine(hitFlash());
            Debug.Log("player takes damage");
            if(currentHealth == 0)
        {
                player.Death();
                healthUI.UpdateHearts(currentHealth);
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


    public void healPlayer()
    {
        if (currentHealth < maxHP)
        {
            currentHealth++;
            healthUI.UpdateHearts(currentHealth);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
