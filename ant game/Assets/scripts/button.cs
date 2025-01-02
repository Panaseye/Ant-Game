using Unity.Multiplayer.Center.Common;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit;

public class button : XRBaseInteractable
{
    public Material touched;
    public Material untouched;
    private new Renderer renderer;
    public gun gun;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        renderer = GetComponent<MeshRenderer>();
    }
    

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        renderer.material = touched;
        gun.Shoot();

        
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        renderer.material = untouched;
        
    }
    
}
