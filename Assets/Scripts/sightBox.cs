using UnityEngine;

public class sightBox : MonoBehaviour
{
    public bool playerFound = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player_movement player = collision.GetComponent <player_movement>();
        if (player != null)
        {
            playerFound= true;
            Debug.Log("Player found!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player_movement player = collision.GetComponent<player_movement>();
        if (player != null)
        {
            playerFound = false;
            Debug.Log("Player not found!");
        }
    }
}
