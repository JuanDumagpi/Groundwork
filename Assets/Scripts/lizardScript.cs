using UnityEngine;
using UnityEditor;


public class lizardScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Transform player;
    public GameObject bullet;
    public float attackSpeed;
    float maxAttackSpeed = 6f;
    public Transform aimPoint;
    public float playerOffsetY;
    public sightBox sight;
    public rangedEnemyScript enemy;
    // Start is called before the first frame update
    void Start()
    {
        attackSpeed = maxAttackSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(player.position.x - transform.position.x, player.position.y + playerOffsetY - transform.position.y);

        transform.up = direction;

        if (attackSpeed <= 0)
        {
            if(sight.playerFound == true)
            {
                StartCoroutine(enemy.attackAnim());
            }
            attackSpeed = maxAttackSpeed;
        }
        else
        {
            attackSpeed -= Time.deltaTime;
        }
        
    }

    //fires the fireball
    public void lizFire()
    {
        GameObject fireBall = Instantiate(bullet, aimPoint.position, transform.rotation);
    }

}

