using UnityEngine;

public class meleeAttack : MonoBehaviour
{
    public int damage = 1;
    public int repair = 1;
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
            craft.craftFix(damage);
        }
    }

}
