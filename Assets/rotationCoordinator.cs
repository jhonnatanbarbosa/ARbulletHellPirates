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

    private void Start()
    {
        // Store the initial rotation of the object
        startRotation = transform.rotation;

        // Find the button by its name (change "YourButtonName" to the actual name of your button)
        Button rotateButton = GameObject.Find("YourButtonName").GetComponent<Button>();

        // Add a listener to the button click
        rotateButton.onClick.AddListener(RotateObject);
    }

    private void RotateObject()
    {
        if (!isRotating)
        {
            // Start the rotation
            isRotating = true;
            startRotation = transform.rotation; // Update the start rotation to the current rotation
            targetRotation = startRotation * Quaternion.Euler(0f, 90f, 0f); // Rotate 90 degrees on the Y-axis
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
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, rotationProgress);

            // Check if the rotation is complete
            if (rotationProgress >= 1f)
            {
                // Stop the rotation
                isRotating = false;
            }
        }
    }
}
