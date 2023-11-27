using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectilePrefab; // Reference to the projectile prefab
    public Transform spawnPoint; // Point from which the projectile is spawned

    public void SpawnProjectile()
    {
        // Spawn a new projectile at the specified spawn point
        GameObject newProjectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
