using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health
    public int currentHealth;

    public  GameObject explosionVFX;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    
    // Function to reduce health
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        GameObject newProjectile = Instantiate(explosionVFX, transform.position, transform.rotation);

        // Check if health is zero or less
        if (currentHealth <= 0)
        {
            
            // If health is zero or less, destroy the object
            Destroy(gameObject);
        }
    }
}
