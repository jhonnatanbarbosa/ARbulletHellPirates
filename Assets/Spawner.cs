using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToInstantiate; // Reference to the prefab to instantiate
    public GameObject objectToLookAt; // Reference to the GameObject to look at

    private float timer = 0f;
    public float spawnInterval = 1f; // Time interval between instantiations
    void Update()
    {
        // Instantiate prefab at regular intervals
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            Instantiate(prefabToInstantiate, transform.position, Quaternion.identity);
            timer = 0f;
        }
    }
}
