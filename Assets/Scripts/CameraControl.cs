using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public GameObject player;
    public float xOffset;
    public float yOffset;
    public float smoothing;
    private Vector3 playerPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // var for finding the player's position in the x and y axis
       playerPosition = new Vector3 (player.transform.position.x, player.transform.position.y + yOffset, transform.position.z);


        // offsets the camera a little bit on the x axis towards where the player is looking
        if(player.transform.localScale.x > 0f ) {
            playerPosition = new Vector3 (playerPosition.x + xOffset, playerPosition.y , playerPosition.z);
        }

        else
        {
            playerPosition = new Vector3(playerPosition.x - xOffset, playerPosition.y, playerPosition.z);
        }

        transform.position = Vector3.Lerp(transform.position, playerPosition, smoothing * Time.deltaTime);
    }
}
