using UnityEngine;

public class meleeAttack : MonoBehaviour
{
    public int damage = 1;
    public int repair = 1;
    public player_movement player;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        rangedEnemyScript renemy = collision.GetComponent<rangedEnemyScript>();
        if (renemy != null)
        {

            renemy.TakeDamage(damage);
        }

        enemyScript enemy = collision.GetComponent<enemyScript>();
        if (enemy != null)
        {

            enemy.TakeDamage(damage);
        }

        breakScript breakables = collision.GetComponent<breakScript>();
        if (breakables != null)
        {
            breakables.TakeDamage(damage);
        }

        copperScript rocks = collision.GetComponent<copperScript>();
        if (rocks != null)
        {
            rocks.TakeDamage(damage);
        }

        craftScript craft = collision.GetComponent<craftScript>();
        if (craft != null)
        {

            craft.craftFix(damage);
        }

        craftUpgrade upgrade = collision.GetComponent<craftUpgrade>();
        if (upgrade != null)
        {
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
