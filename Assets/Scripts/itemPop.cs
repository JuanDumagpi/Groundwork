using UnityEngine;

public class itemPop : MonoBehaviour
{
    private Rigidbody2D rb;
    public float force = 3;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        Physics2D.IgnoreLayerCollision(6, 6, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
