using System.Collections;
using UnityEngine;

public class craftUpgrade : MonoBehaviour
{
    public craftScript CraftingScript;
    public Transform spawnPoint;
    public GameObject turret;
    public bool invuln = false;
    public float iFrameDuration = 1;
    Items resources;
    player_movement player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resources = FindFirstObjectByType<Items>(); //refers to the item script
        player = FindFirstObjectByType<player_movement>(); //refers to the player script
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void upgradeWallRight()
    {
        if (CraftingScript.health >= CraftingScript.maxHealth && resources.silverCount >= 1)
        {
            if (invuln == false)
            {
                Destroy(gameObject);
                GameObject cloneTurret = Instantiate(turret, spawnPoint.position, spawnPoint.rotation);
                resources.silverCount--;
                Debug.Log("Trying to make turret");

            }
            else
            {
                Debug.Log("Hitting too fast, wait a bit");
            }
        }
        else
        {
            Debug.Log("Cant Upgrade! Not enough silver maybe?");
        }
        StartCoroutine(IFrame());
    }

    public void upgradeWallLeft()
    {
        if (CraftingScript.health >= CraftingScript.maxHealth)
        {
            if (invuln == false)
            {
                Destroy(gameObject);
                GameObject cloneTurret = Instantiate(turret, spawnPoint.position, Quaternion.Euler(0,180,0));
                Debug.Log("Trying to make turret");

            }
        }
        else
        {
            Debug.Log("Cant Upgrade!");
        }
        StartCoroutine(IFrame());
    }


    IEnumerator IFrame()
    {
        invuln = true;
        yield return new WaitForSeconds(iFrameDuration);
        invuln = false;
    }
}
