using UnityEngine;
using UnityEngine.AI;

public class clone : MonoBehaviour
{
    public float speed;
    public GameObject antEnd;
    public NavMeshAgent navMeshAgent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(antEnd.transform.position);
        
    }
}
