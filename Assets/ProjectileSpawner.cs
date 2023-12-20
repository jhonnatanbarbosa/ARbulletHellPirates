using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectilePrefab; // Reference to the projectile prefab
    public Transform spawnPoint; // Point from which the projectile is spawned
    public GameObject player; // Reference to the player

    private void Update() {
        //keep transform of spawner the same as the player
        transform.position = player.transform.position;
        transform.rotation = player.transform.rotation;
    }
    public void SpawnProjectile()
    {
        // Spawn a new projectile at the specified spawn point
        GameObject newProjectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
    }
}