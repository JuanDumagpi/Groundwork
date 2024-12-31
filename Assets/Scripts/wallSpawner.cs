using UnityEngine;

public class wallSpawner : MonoBehaviour
{
    public GameObject wallObject;
    public Transform spawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   //calls the makeWall function when right click is pressed
        if (Input.GetButtonDown("Fire2"))
        {
            makeWall();
        }
    }

    void makeWall()
    {   //instantiates a wall block that can be used as a platform or block enemies
        Instantiate(wallObject, spawnPoint.position, spawnPoint.rotation);
    }
}
