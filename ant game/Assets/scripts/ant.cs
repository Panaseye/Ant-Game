using UnityEngine;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(CharacterController))]
public class ant : XRBaseInteractable
{
    public GameObject message;
    public Transform vrRig;
    public Transform seat;
    public float transitionSpeed = 3f;
    public Canvas canvas;
    public CanvasGroup fadeCanvas;
    public float fadeDuration = 1f;
    public bool shakad = false;
    public bool isRiding = false;
    private bool isHovering = false; // Tracks whether the player is hovering over the ant
    private Collider antCollider;
    private Collider vrRigCollider;

    protected override void Awake()
    {
        base.Awake();
        canvas = GetComponentInChildren<Canvas>();
        canvas.gameObject.SetActive(false);
        seat = transform.Find("seat");
        antCollider = GetComponent<Collider>(); // Get the ant's collider
        vrRigCollider = vrRig.GetComponent<Collider>(); // Get the VR rig's collider
    }

    void Update()
    {
        // If riding, smoothly follow the ant's position and rotation
        if (isRiding)
        {
            vrRig.position = Vector3.Lerp(vrRig.position, seat.position + new Vector3(0, 1f, 0), Time.deltaTime * transitionSpeed);
            vrRig.rotation = Quaternion.Slerp(vrRig.rotation, seat.rotation, Time.deltaTime * transitionSpeed);
        }
    }

    // Start riding
    public void StartRiding()
    {
        // Only start riding if the player is hovering
        if (isHovering)
        {
            StartCoroutine(FadeAndRide(true));

            // Move the VR rig to the seat's position and align its rotation to the seat
            vrRig.position = seat.position + new Vector3(0, 1f, 0);  // Adjust offset to fit the seat
            vrRig.rotation = seat.rotation;  // Align rotation to seat's rotation

            // Ignore collisions between VR rig and ant during riding
            Physics.IgnoreCollision(vrRigCollider, antCollider, true);

            isRiding = true;
        }
    }

    // Stop riding
    public void StopRiding()
    {
        // Only stop riding if the player is hovering
        if (isHovering)
        {
            StartCoroutine(FadeAndRide(false));

            // After fading out, teleport the VR rig to a safe exit point
            vrRig.position = new Vector3(0, 1f, 0);  // Adjust to a safe exit location
            vrRig.rotation = Quaternion.identity;  // Reset rotation to default orientation

            // Re-enable collisions between VR rig and ant after dismounting
            Physics.IgnoreCollision(vrRigCollider, antCollider, false);

            isRiding = false;
        }
    }

    private IEnumerator FadeAndRide(bool start)
    {
        // Fade to black before moving or teleporting
        yield return Fade(start ? 1 : 0);

        // If not riding, teleport to the seat's position and rotation
        if (start)
        {
            vrRig.position = seat.position + new Vector3(0, 1f, 0);  // Adjust position to fit the seat
            vrRig.rotation = seat.rotation;  // Align rotation to seat's rotation
        }

        // Fade back in (for mounting or dismounting)
        yield return Fade(start ? 0 : 1);
    }

    private IEnumerator Fade(float targetAlpha)
    {
        float startAlpha = fadeCanvas.alpha;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadeCanvas.alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            yield return null;
        }

        fadeCanvas.alpha = targetAlpha;

        // After fade out, ensure the canvas is hidden if stopping the ride
        if (targetAlpha == 0)
        {
            canvas.gameObject.SetActive(false);
        }
        else if (targetAlpha == 1)
        {
            // Ensure it's visible when fading back in
            canvas.gameObject.SetActive(true);
        }
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        // Mark that the player is hovering over the ant
        isHovering = true;
        if (!isRiding)
        {
            canvas.gameObject.SetActive(true); // Show gesture prompt
        }
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        // Mark that the player is no longer hovering over the ant
        isHovering = false;
        canvas.gameObject.SetActive(false); // Hide gesture prompt
    }

    public void Shakad()
    {
        // Toggle riding status based on current state
        if (!isRiding && isHovering)
        {
            // Start riding if not already riding and hovering
            StartRiding();
        }
        else if (isRiding && isHovering)
        {
            // Stop riding if already riding and hovering
            StopRiding();
        }
    }

    public void UnShakad()
    {
        shakad = false;
    }

    public void PoopMessage(string theMessage)
    {
        Instantiate(message, gameObject.transform);
        message.GetComponent<message>().antSay = theMessage;
    }
}
