using System;
using System.Collections;
using UnityEngine;

public class craftScript : MonoBehaviour
{
    float maxHealth = 5f;
    float health;
    private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 1f;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void craftFix(float repair)
    {
        if (health < maxHealth)
        {
            health += repair;
            Debug.Log("Wall health is" + health);
        }
        else
        {
            Debug.Log("Wall health is max!");
            StartCoroutine(repairComplete());
        }
    }

    private IEnumerator repairComplete()
    {
        spriteRenderer.color = Color.green;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }
}
