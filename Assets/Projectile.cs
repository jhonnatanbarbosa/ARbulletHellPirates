using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f; // Speed of the projectile
    public float lifetime = 3f; // Time before the projectile self-destructs
    public string targetTag1 = "Player"; // Tag of the object to be considered as the player target
    public string targetTag2 = "Enemy"; // Tag of the object to be considered as the enemy target
    public int damageAmount = 20; // Amount of damage the projectile inflicts

    private void Start()
    {
        // Launch the projectile forward
        Rigidbody rb = GetComponent<Rigidbody>();
        // Rotate the object 90 in the x axis so it faces the right way
        transform.Rotate(270f, 0, 0);
        rb.velocity = transform.up * -speed;

        // Destroy the projectile after the specified lifetime
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the specified tag
        /*if (other.CompareTag(targetTag1))
        {
            // If the collided object has the specified tag, destroy the projectile
            Destroy(gameObject);
            // You can add code here to handle what happens when the projectile hits the player
        }*/

        // Check if the collided object has the specified tag
        if (other.CompareTag(targetTag2))
        {
            // If the collided object has the specified tag, reduce the enemy's health
            Health enemyHealth = other.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount);
                Debug.Log("Enemy health: " + enemyHealth.currentHealth);
            }
            else
            {
                Debug.Log("Enemy has no health script");
            }
            
            // Destroy the projectile
            Destroy(gameObject);
            // You can add code here to handle what happens when the projectile hits the enemy
        }
    }
}
