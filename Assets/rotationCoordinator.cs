using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationCoordinator : MonoBehaviour
{
    public float rotationSpeed = 1f;
    private bool isRotating = false;
    private float rotationProgress = 0f;
    private Quaternion startRotation;
    private Quaternion targetRotation;
    public GameObject objectToRotate; // GameObject to be rotated

    /*private void Start()
    {
    Button rotateCWButton = GameObject.Find("RotateCWButton").GetComponent<Button>();
    rotateCWButton.onClick.AddListener(() => RotateCW(objectToRotate));

    Button rotateCCWButton = GameObject.Find("RotateCCWButton").GetComponent<Button>();
    rotateCCWButton.onClick.AddListener(() => RotateCCW(objectToRotate));
    }*/


    // Method to rotate the specified object clockwise
    public void RotateCW()
    {
        if (!isRotating)
        {
            // Start the rotation
            isRotating = true;
            startRotation = objectToRotate.transform.rotation; // Update the start rotation to the current rotation of the specified object
            targetRotation = startRotation * Quaternion.Euler(0f, 90f, 0f); // Rotate 90 degrees on the Y-axis
            rotationProgress = 0f; // Reset the rotation progress
        }
    }

    // Method to rotate the specified object counter-clockwise
    public void RotateCCW()
    {
        if (!isRotating)
        {
            // Start the rotation
            isRotating = true;
            startRotation = objectToRotate.transform.rotation; // Update the start rotation to the current rotation of the specified object
            targetRotation = startRotation * Quaternion.Euler(0f, 90f, 0f); // Rotate -90 degrees on the Y-axis
            rotationProgress = 0f; // Reset the rotation progress
        }
    }

    private void Update()
    {
        if (isRotating)
        {
            // Increase the rotation progress over time using Lerp
            rotationProgress += rotationSpeed * Time.deltaTime;
            rotationProgress = Mathf.Clamp01(rotationProgress);

            // Update the object's rotation using Lerp
            objectToRotate.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, rotationProgress);

            // Check if the rotation is complete
            if (rotationProgress >= 1f)
            {
                // Stop the rotation
                isRotating = false;
            }
        }
    }
}