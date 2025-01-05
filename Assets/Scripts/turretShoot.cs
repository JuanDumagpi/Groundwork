using UnityEngine;

public class turretShoot : MonoBehaviour
{
    public Transform aimPoint; //reference to the Turret's aimPoint
    public float attackSpeed;
    public float maxAttackSpeed;
    public GameObject bullet; //reference to the Turret's projectile
    public float turretRange; //reference to how far the turret can see before it shoots
    public LayerMask enemyLayer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        
        if (attackSpeed <= 0 )
        {
            Shoot();
            attackSpeed = maxAttackSpeed;
        }
        attackSpeed -= Time.deltaTime;
        
    }

    public void Shoot()
    {
        RaycastHit2D hit = Physics2D.Raycast(aimPoint.position, Vector2.right, turretRange, enemyLayer);
        if (hit.collider != null)
        {
        Debug.Log("enemy found!");
        Instantiate(bullet, aimPoint.position, aimPoint.rotation);
        }
    }

}
