using UnityEngine;

public class player : MonoBehaviour
{

     public Transform character;
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
        Vector3 forward = vrCamera.forward;
        forward.y = 0;
        character.position += forward * speed * Time.deltaTime;
    }
    


}
