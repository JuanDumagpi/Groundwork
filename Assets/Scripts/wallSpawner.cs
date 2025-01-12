using UnityEngine;

public class wallSpawner : MonoBehaviour
{
    public GameObject wallObject; //refers to the prefab
    public Transform spawnPoint; //refers to where the item will spawn, childed to the player
    Items resources; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resources = FindFirstObjectByType<Items>(); //refers to the item script

    }

    // Update is called once per frame
    void Update()
    {   //calls the makeWall function when right click is pressed
        if (Input.GetButtonDown("Fire2"))
        {
            if (resources.copperCount >= 1)
            {
                makeWall();
                resources.copperCount--;
                resources.updateCopperAmt();
            }
            else
            {
                Debug.Log("Not enough copper to make a wall!");
            }
        }
    }

    void makeWall()
    {   //instantiates a wall block that can be used as a platform or block enemies
        GameObject cloneWall = Instantiate(wallObject, spawnPoint.position, spawnPoint.rotation);
    }
}
