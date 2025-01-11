using System.Numerics;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;
public class player : MonoBehaviour
{

    public Transform character;
    public CharacterController characterController;
    public Transform vrCamera;
    public float speed = 1f;
    private bool isMoving = false;
    
   

     
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
         if (isMoving)
        {
            MoveForward();
        }
        ApplyGravity();
    }

    public void MovePlayer()
    {
        // Start the player's movement
        isMoving = true;
    }

    public void StopPlayer()
    {
        // Stop the player's movement
        isMoving = false;
    }

    private void MoveForward()
    {
         // Calculate the forward direction relative to the VR camera
    Vector3 forward = vrCamera.forward;
    forward.y = 0; // Keep movement on the horizontal plane
    forward.Normalize(); // Ensure the direction vector is normalized

    // Use Rigidbody to move the character
    Vector3 moveOffset = forward * speed * Time.deltaTime;
    characterController.Move(moveOffset);
    }

    private void ApplyGravity()
{
    if (!characterController.isGrounded)
    {
        Vector3 gravity = new Vector3(0, -9.81f, 0); // Adjust gravity as needed
        characterController.Move(gravity * Time.deltaTime);
    }
}

    
}
