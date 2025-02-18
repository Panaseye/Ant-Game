using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit;
public class message : XRBaseInteractable
{
    public Material touched;
    public Material untouched;
    public string antSay;
    private new Renderer renderer;
    [SerializeField] TextMeshProUGUI messageText;
    public Canvas messageUI;
    public AudioSource sound; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Awake()
    {   
        base.Awake();
        renderer = GetComponent<MeshRenderer>();
        messageText= GetComponentInChildren<TextMeshProUGUI>();
        messageUI = GetComponentInChildren<Canvas>();
        sound = GetComponent<AudioSource>();
        

        messageText.text = antSay;
        messageUI.gameObject.SetActive(false);
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        renderer.material = touched;
        messageUI.gameObject.SetActive(true);
        sound.Play();
      
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        renderer.material = untouched;
        messageUI.gameObject.SetActive(false);

    }

    


}
