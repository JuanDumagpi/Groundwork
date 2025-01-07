using UnityEngine;

public class meleeAttack : MonoBehaviour
{
    public int damage = 1;
    public int repair = 1;
    public player_movement player;
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

        craftUpgrade upgrade = collision.GetComponent<craftUpgrade>();
        if (upgrade != null)
        {

            Debug.Log("Upgrades?");
            if (player.isRight==true)
            {
                upgrade.upgradeWallRight();
            }
            else
            {
                upgrade.upgradeWallLeft();
            }
        }
    }

}
