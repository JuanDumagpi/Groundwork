using UnityEngine;

public class skellySpawner : MonoBehaviour
{
    public float minSpawnTime;
    public float maxSpawnTime;
    public float timeToSpawn;
    public GameObject skelly;



    //using Awake so it works when the spawners are enabled
    void Awake()
    {
        setSpawnTime();
    }

    // Update is called once per frame
    void Update()
    {
        timeToSpawn-= Time.deltaTime;
        if(timeToSpawn <= 0 ) 
        {
            Instantiate(skelly, transform.position, transform.rotation);
            setSpawnTime();
        }
    }

    private void setSpawnTime()
    {
        timeToSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
