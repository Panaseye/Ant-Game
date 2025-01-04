using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class gun : XRGrabInteractable

{
    public LineRenderer lineRenderer; // The line renderer for the string
    public float shootForce = 10f; // Speed at which the string extends
    public float maxLength = 10f; // Maximum length of the string
    private bool isShooting = false;
     private Vector3 currentEndPosition;

    public  GameObject ammo;
    public Transform shooterPoint;
    public float pulsePower = 100f;
    
     void Start()
    {
       
        currentEndPosition = transform.position; // Set the initial end position to gun position
    }
  
    public void Shoot()
    {
        GameObject newAmmo = Instantiate(ammo, shooterPoint.position, shooterPoint.rotation);

    
        Rigidbody ammoRigidbody = newAmmo.GetComponent<Rigidbody>();

        Vector3 forceDirection = shooterPoint.right; // Direction of the force
      

        ammoRigidbody.AddForce(forceDirection * pulsePower, ForceMode.Impulse);
        


    }
   public void StartShooting()
    {
        // Activate the line renderer to start drawing the string
        lineRenderer.enabled = true;
        isShooting = true;

        // Set the start of the string at the gun position
        lineRenderer.SetPosition(0, transform.position);

        // Begin extending the string
        currentEndPosition = transform.position; // Reset to the gun's position
    }

    public void ExtendString()
    {
        if (isShooting)
        {
            // Calculate the direction in front of the gun
            Vector3 shootDirection = transform.forward;

            // Move the end of the string forward
            currentEndPosition += shootDirection * shootForce * Time.deltaTime;

          
        }
    }

    public void StopShooting()
    {
        if (isShooting)
        {
            // Disable the line renderer when the button is released
            lineRenderer.enabled = false;
            isShooting = false;
        }
    }


}
    

    

   

