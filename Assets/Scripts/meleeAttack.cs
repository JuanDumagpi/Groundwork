using UnityEngine;

public class meleeAttack : MonoBehaviour
{
    public int damage = 1;
    public int repair = 1;
    public player_movement player;
    public AudioSource hitAudio;
    public AudioSource thunkAudio;
    private void Start()
    {
        hitAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hitAudio.pitch = UnityEngine.Random.Range(1f, 2f);
        thunkAudio.pitch = UnityEngine.Random.Range(0.9f, 1.2f);

        rangedEnemyScript renemy = collision.GetComponent<rangedEnemyScript>();
        if (renemy != null)
        {
            hitAudio.Play();
            renemy.TakeDamage(damage);
        }

        enemyScript enemy = collision.GetComponent<enemyScript>();
        if (enemy != null)
        {
            hitAudio.Play();
            enemy.TakeDamage(damage);
        }

        skellyScript skelly = collision.GetComponent<skellyScript>();
        if (skelly != null)
        {
            hitAudio.Play();
            skelly.TakeDamage(damage);
        }

        breakScript breakables = collision.GetComponent<breakScript>();
        if (breakables != null)
        {
            hitAudio.Play();
            breakables.TakeDamage(damage);
        }

        copperScript rocks = collision.GetComponent<copperScript>();
        if (rocks != null)
        {
            thunkAudio.Play();
            rocks.TakeDamage(damage);
        }

        craftScript craft = collision.GetComponent<craftScript>();
        if (craft != null)
        {
            thunkAudio.Play();
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
            thunkAudio.Play();
        }
    }

}
