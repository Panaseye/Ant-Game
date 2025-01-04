using UnityEngine;
using System.Collections;


[RequireComponent(typeof(CharacterController))]
public class ant : MonoBehaviour
{ 
    public float speed = 2.0f; // Speed of the ant
    public float directionChangeInterval = 1.0f; // Time between direction changes
    public float maxHeadingChange = 30f; // Maximum change in direction per interval
    public float pauseChance = 0.3f; // Probability of pausing at each interval

    private CharacterController controller;
    private float heading;
    private Vector3 targetRotation;
    private bool isPaused = false;

    public GameObject message;

	 void Awake()
    {
        controller = GetComponent<CharacterController>();

        // Set random initial rotation
        heading = Random.Range(0, 360);
        transform.eulerAngles = new Vector3(0, heading, 0);

        StartCoroutine(MovementRoutine());
    }

    void Update()
    {
        if (!isPaused)
        {
            // Smoothly rotate towards the target direction
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);

            // Move forward in the current direction
            var forward = transform.TransformDirection(Vector3.forward);
            controller.SimpleMove(forward * speed);
        }
    }

    /// <summary>
    /// Main movement routine.
    /// </summary>
    IEnumerator MovementRoutine()
    {
        while (true)
        {
            // Random chance to pause
            if (Random.value < pauseChance)
            {
                isPaused = true;
                yield return new WaitForSeconds(Random.Range(0.5f, 1.5f)); // Pause for a random duration
                isPaused = false;
            }

            // Change direction
            NewHeadingRoutine();
            yield return new WaitForSeconds(directionChangeInterval);
        }
    }

    /// <summary>
    /// Calculates a new random direction to move towards.
    /// </summary>
    void NewHeadingRoutine()
    {
        var floor = Mathf.Clamp(heading - maxHeadingChange, 0, 360);
        var ceil = Mathf.Clamp(heading + maxHeadingChange, 0, 360);
        heading = Random.Range(floor, ceil);
        targetRotation = new Vector3(0, heading, 0);
    }

    public void PoopMessage(string theMessage)
    {
        Instantiate(message,gameObject.transform);
        message.GetComponent<message>().antSay = theMessage;

    }
}