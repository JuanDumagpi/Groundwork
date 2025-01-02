using UnityEngine;

public class meleeAttack : MonoBehaviour
{
    public float damage = 1;
    public float repair = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        enemyScript enemy = collision.GetComponent<enemyScript>();
        if (enemy != null)
        {
            Debug.Log("Hits");
            enemy.TakeDamage(damage);
        }

        craftScript craft = collision.GetComponent<craftScript>();
        if (craft != null)
        {
            Debug.Log("Hits");
            craft.craftFix(repair);
        }
    }

}
