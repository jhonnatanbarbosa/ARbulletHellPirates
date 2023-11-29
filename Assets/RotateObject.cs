using UnityEngine;
using UnityEngine.UI;

public class RotateObject : MonoBehaviour
{
    public GameObject objectToRotate; // Reference to the object you want to rotate
    public float rotationAmount = 90f; // Amount of rotation in degrees

    // Function to rotate the object clockwise by 90 degrees along the Y-axis
    public void RotateClockwise()
    {
        RotateObjectByAmount(rotationAmount);
    }

    // Function to rotate the object counterclockwise by 90 degrees along the Y-axis
    public void RotateCounterClockwise()
    {
        RotateObjectByAmount(-rotationAmount);
    }

    // Rotate the object by the specified amount along the Y-axis
    private void RotateObjectByAmount(float amount)
    {
        if (objectToRotate != null)
        {
            objectToRotate.transform.Rotate(Vector3.up, amount);
        }
        else
        {
            Debug.LogWarning("No object to rotate assigned!");
        }
    }
}
