using UnityEngine;

public class shootable : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public Collider collider1;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       meshRenderer =  gameObject.GetComponent<MeshRenderer>();
       meshRenderer.enabled = false;
       collider1.enabled = false;
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
            collider1.enabled = true;
            Destroy(other.gameObject);

        }
        
    }
}
