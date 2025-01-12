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
    public int ammo = 15; //destroys gameobject if it runs out of ammo
    public float lifespan = 30; //destroys the game object if inactive for 30s
    public GameObject silver;

    public AudioSource shot;
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
        
        if (lifespan <= 0 || ammo <= 0)
        {
            GameObject scrap = Instantiate(silver, aimPoint.position, aimPoint.rotation);
            Destroy(gameObject);
        }
        lifespan -= Time.deltaTime;
    }

    public void Shoot()
    {
        RaycastHit2D hit = Physics2D.Linecast(aimPoint.position, endPoint.position, enemyLayer);
        Debug.DrawLine(aimPoint.position, endPoint.position);
        if (hit.collider != null)
        {
            shot.pitch = UnityEngine.Random.Range(0.6f, 0.9f);
            shot.Play();
            Debug.Log("enemy found!");
            Instantiate(bullet, aimPoint.position, aimPoint.rotation);
            lifespan = 30;
            ammo--;
        }
    }

}
