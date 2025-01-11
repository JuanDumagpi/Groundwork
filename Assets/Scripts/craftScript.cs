using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class craftScript : MonoBehaviour
{
    public int maxHealth;
    public int health;
    private SpriteRenderer spriteRenderer;
    public float iFrameDuration;
    private bool invuln = false;
    public Transform spawnPoint;
    public GameObject copper; // when the crafted object is destroyed you get a refun of resources!

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 1;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void craftFix(int repair)
    {
        if (health < maxHealth && invuln == false)
        {
            health += repair;
            
        }
        StartCoroutine(IFrame());
    }

    public void craftDamage(int damage)
    {
        health -= damage;
        StartCoroutine(hitFlash());
        if (health <= 0)
        {
            GameObject scrap = Instantiate(copper, spawnPoint.position, spawnPoint.rotation);
            Destroy(gameObject);
        }
    }

    IEnumerator IFrame()
    {
        invuln = true;

        if (health < maxHealth)
        {
            spriteRenderer.color = Color.green;
        }
        else
        {
            spriteRenderer.color = Color.cyan;
        }
        yield return new WaitForSeconds(iFrameDuration);
        spriteRenderer.color = Color.white;
        invuln = false;
    }

    private IEnumerator hitFlash()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }
}
