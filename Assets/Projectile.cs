using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f; // Speed of the projectile
    public float lifetime = 3f; // Time before the projectile self-destructs
    public string targetTag = "Player"; // Tag of the object to be considered as the target

    private void Start()
    {
        // Launch the projectile forward
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;

        // Destroy the projectile after the specified lifetime
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the specified tag
        if (collision.collider.CompareTag(targetTag))
        {
            // If the collided object has the specified tag, destroy the projectile
            Destroy(gameObject);
            // You can add code here to handle what happens when the projectile hits the target
        }
    }
}
