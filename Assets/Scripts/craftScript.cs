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
            Debug.Log("Object health is" + health);
        }
        else
        {
            Debug.Log("Object health didnt change!");

        }
        StartCoroutine(IFrame());
    }

    private IEnumerator repairComplete()
    {
        spriteRenderer.color = Color.green;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }

    public void craftDamage(int damage)
    {
        health -= damage;
        Debug.Log("wall takes damage");
        if (health <= 0)
        {
            GameObject scrap = Instantiate(copper, spawnPoint.position, spawnPoint.rotation);
            Destroy(gameObject);
        }
    }

    IEnumerator IFrame()
    {
        invuln = true;
        yield return new WaitForSeconds(iFrameDuration);
        invuln = false;
    }

}
