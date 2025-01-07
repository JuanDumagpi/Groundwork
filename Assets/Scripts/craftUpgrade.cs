using System.Collections;
using UnityEngine;

public class craftUpgrade : MonoBehaviour
{
    public craftScript CraftingScript;
    public Transform spawnPoint;
    public GameObject turret;
    public bool invuln = false;
    public float iFrameDuration = 1;

    public player_movement player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void upgradeWallRight()
    {
        if (CraftingScript.health >= CraftingScript.maxHealth)
        {
            if (invuln == false)
            {
                Destroy(gameObject);
                Instantiate(turret, spawnPoint.position, spawnPoint.rotation);
                Debug.Log("Trying to make turret");

            }
        }
        else
        {
            Debug.Log("Cant Upgrade!");
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
                Instantiate(turret, spawnPoint.position, Quaternion.Euler(0,180,0));
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
