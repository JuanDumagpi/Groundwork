using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class turretShoot : MonoBehaviour
{
    public Transform aimPoint; //reference to the Turret's aimPoint
    public Transform endPoint; //reference to the Turret's endPoint
    public float attackSpeed;
    public float maxAttackSpeed;
    public GameObject bullet; //reference to the Turret's projectile
    private int lineDist;
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
        RaycastHit2D hit = Physics2D.Linecast(aimPoint.position, endPoint.position, enemyLayer);
        Debug.DrawLine(aimPoint.position, endPoint.position);
        if (hit.collider != null)
        {
        Debug.Log("enemy found!");
        Instantiate(bullet, aimPoint.position, aimPoint.rotation);
        }
    }

}
