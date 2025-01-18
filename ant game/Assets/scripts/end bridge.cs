using UnityEngine;

public class endbridge : MonoBehaviour
{
    public Canvas canvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        canvas = GetComponentInChildren<Canvas>();
        canvas.gameObject.SetActive(false);
    }

    void OnTriggerEnter()
    {
        canvas.gameObject.SetActive(true);
        
    }
    
    void OnTriggerExit()
    {
        canvas.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
