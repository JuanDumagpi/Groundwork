using UnityEngine;

public class enemyScript : MonoBehaviour
{
    float health, maxHealth = 5f;
    public int damagePlayer = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Slime is " + health);
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
