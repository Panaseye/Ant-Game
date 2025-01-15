using System.ComponentModel;
using UnityEngine;

public class floatRotate : MonoBehaviour
{
    public Transform center;

    public float floatSpeed = 1f;  // Speed of the up-and-down motion
    public float floatHeight = 0.5f;  // Height of the up-and-down motion
    public float rotationSpeed = 50f;  // Speed of rotation

    private Vector3 initialPosition;  // Store the initial position of the object

    void Start()
    {
        // Record the object's starting position
        initialPosition = center.position;
    }

    void Update()
    {
        // Make the object float up and down
        float newY = initialPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        center.position = new Vector3(center.position.x, newY, center.position.z);

        // Rotate the object around the Y-axis
        center.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
