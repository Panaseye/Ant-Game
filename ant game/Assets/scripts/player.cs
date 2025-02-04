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
    public Transform spawningPoint;
    public float speed = 1f;
    public float speedMulti = 1f;
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

        if (characterController.isGrounded)
        {
            spawningPoint.position = gameObject.transform.position;
        }


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

    public void SpeedMulti()
    {
        speedMulti = 2;
    }

    public void StopMulti()
    {
        speedMulti = 1;
    }

    private void MoveForward()
    {
         // Calculate the forward direction relative to the VR camera
    Vector3 forward = vrCamera.forward;
    forward.y = 0; // Keep movement on the horizontal plane
    forward.Normalize(); // Ensure the direction vector is normalized

    // Use Rigidbody to move the character
    Vector3 moveOffset = forward * speed * speedMulti * Time.deltaTime;
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
