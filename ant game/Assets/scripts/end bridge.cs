using UnityEngine;

public class endbridge : MonoBehaviour
{
    public Canvas canvas;
    public AudioSource  sound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        canvas = GetComponentInChildren<Canvas>();
        canvas.gameObject.SetActive(false);
        sound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter()
    {
        canvas.gameObject.SetActive(true);
        sound.Play();
    }

    void OnTriggerExit()
    {
        canvas.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
