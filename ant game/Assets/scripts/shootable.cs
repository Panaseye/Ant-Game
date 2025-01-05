using UnityEngine;

public class shootable : MonoBehaviour
{
    public MeshRenderer meshRenderer;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       meshRenderer =  gameObject.GetComponent<MeshRenderer>();
       meshRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ammo"))
        {
            meshRenderer.enabled = true;
            Destroy(other.gameObject);

        }
        
    }
}
