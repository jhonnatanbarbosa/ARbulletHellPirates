using UnityEngine;

public class SineWaveMovement : MonoBehaviour
{
    public float amplitude = 1f;   // Amplitude of the sine wave
    public float frequency = 1f;   // Frequency of the sine wave
    public float rotationAmount = 10f;  // Amount of rotation when going up or down

    private float startTime;        // Starting time of the movement

    private float timeOffset = 0f;   // Time offset to start the movement
    private float initialY;         // Initial Y position of the object

    private Transform parentTransform; // Reference to the parent's transform

    void Start()
    {
        timeOffset = Random.Range(0f, 5f);  // Randomize the time offset

        startTime = Time.time + timeOffset;  // Record the starting time
        initialY = transform.localPosition.y;  // Record the initial local Y position

        // Get the parent's transform
        parentTransform = transform.parent;
    }

    void Update()
    {
        // Calculate the Y position using a sine wave equation, with the center at initialY
        float yPos = Mathf.Sin((Time.time - startTime) * frequency) * amplitude + initialY;

        // Update the object's local position relative to the parent
        transform.localPosition = new Vector3(transform.localPosition.x, yPos, transform.localPosition.z);

        // Calculate rotation based on the parent's rotation and sine wave value
        float rotationValue = Mathf.Sin((Time.time - startTime) * frequency) * rotationAmount;

        // Apply rotation to the object using parent's rotation
        Quaternion parentRotation = parentTransform.rotation;
        Quaternion localRotation = Quaternion.Euler(rotationValue, 0f, 0f);
        Quaternion finalRotation = parentRotation * localRotation;

        // Apply the final rotation to the object
        transform.rotation = finalRotation;
    }
}
