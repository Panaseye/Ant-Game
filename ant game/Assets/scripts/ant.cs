using UnityEngine;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.AI;

[RequireComponent(typeof(CharacterController))]
public class ant : XRBaseInteractable
{
    public GameObject message;
    
    public NavMeshAgent agent;
    public Transform player;
    public float followDistance;
    public startFollow startFollow;

    private bool isHovering = false; // Tracks whether the player is hovering over the ant
  
    protected override void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = followDistance;
    
        
    }

    void Update()
    {
       if(startFollow.startBridge)
       {
        followPlayer();
       }
        
        
        
    }

    void followPlayer()
    {
        Debug.Log("player: " + player.position + "distance: " + followDistance);
        if (Vector3.Distance(transform.position, player.position) > followDistance)
        {
            Debug.Log("should follow");
            agent.SetDestination(player.position);
        }
        else
        {
            Debug.Log("got to the else");
            agent.ResetPath();
        }
    }

    

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        // Mark that the player is hovering over the ant
        isHovering = true;
        
        
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        // Mark that the player is no longer hovering over the ant
        isHovering = false;
        
    }

    

    public void PoopMessage(string theMessage)
    {
        Instantiate(message, gameObject.transform) ;
        message.GetComponent<message>().antSay = theMessage;
    }
}
