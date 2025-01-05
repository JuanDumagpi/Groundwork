using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = transform.right * bulletSpeed;
    }
}
