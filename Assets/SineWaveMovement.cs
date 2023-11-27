using UnityEngine;

public class SineWaveMovement : MonoBehaviour
{
    public float amplitude = 1f;   // Amplitude of the sine wave
    public float frequency = 1f;   // Frequency of the sine wave
    public float rotationAmount = 10f;  // Amount of rotation when going up or down

    private float startTime;        // Starting time of the movement

    private float timeOffset = 0f;   // Time offset to start the movement
    private float initialY;         // Initial Y position of the object

    void Start()
    {
        timeOffset = Random.Range(0f, 5f);  // Randomize the time offset

        startTime = Time.time + timeOffset;  // Record the starting time
        initialY = transform.position.y;  // Record the initial Y position
    }

    void Update()
    {
        // Calculate the Y position using a sine wave equation, with the center at initialY
        float yPos = Mathf.Sin((Time.time - startTime) * frequency) * amplitude + initialY;

        // Update the object's position
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);

        // Calculate rotation based on the sine wave value
        float rotationValue = Mathf.Sin((Time.time - startTime) * frequency) * rotationAmount;

        // Apply rotation to the object
        transform.rotation = Quaternion.Euler(new Vector3(rotationValue, 0f, 0f));
    }
}
