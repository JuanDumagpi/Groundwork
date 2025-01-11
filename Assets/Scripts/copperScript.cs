using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class copperScript : MonoBehaviour
{
    public int health;
    public int maxHealth = 3;
    public GameObject copper;
    //makes a list of items this gameobject can drop
    public GameObject[] lootTable;
    public float iFrameDuration =0.25f;
    public bool invuln = false;
    private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        health--;
        StartCoroutine(IFrame());
        if (health <= 0)
        {
            lootDrop();
            Destroy(gameObject);
        }
    }

    private void lootDrop()
    {
        for (int i = 0; i < lootTable.Length; i++)
        {
            Instantiate(lootTable[i], transform.position, transform.rotation);
        }
    }

    IEnumerator IFrame()
    {
        invuln = true;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(iFrameDuration);
        spriteRenderer.color = Color.grey;
        invuln = false;
    }
}

