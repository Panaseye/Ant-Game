using Unity.Multiplayer.Center.Common;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class gun : XRGrabInteractable

{
    
    public  GameObject ammo;
    public Transform shooterPoint;
    public float pulsePower = 100f;

    public bool isGrabbed = false;
    
     void Start()
    {
       
        
    }
  
    public void Shoot()
    {
        GameObject newAmmo = Instantiate(ammo, shooterPoint.position, shooterPoint.rotation);

    
        Rigidbody ammoRigidbody = newAmmo.GetComponent<Rigidbody>();

        Vector3 forceDirection = shooterPoint.right; // Direction of the force
      

        ammoRigidbody.AddForce(forceDirection * pulsePower, ForceMode.Impulse);
        


    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        isGrabbed = true;

    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        isGrabbed = false;
    }


}
    

    

   

