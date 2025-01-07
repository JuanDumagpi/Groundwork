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
            Debug.Log("Wall health is" + health);
        }
        else
        {
            Debug.Log("Wall health is didnt change!");

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
