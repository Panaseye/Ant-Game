using Unity.Multiplayer.Center.Common;
using UnityEngine;
using UnityEngine.AI;

public class respawner : MonoBehaviour
{

    public GameObject character;
    public GameObject gun;
    public GameObject ant;
    public Transform gunSpawn;
    public Transform antSpawn;
    public Transform characterSpawn;
    public startFollow startFollow;
    public Transform antLoop;
    public AudioSource sound;

    
   void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ammo"))
        {
            Destroy(other.gameObject);
        }else if (other.gameObject.CompareTag("clone"))
        {
            other.GetComponent<NavMeshAgent>().enabled = false;
            other.transform.position = antLoop.position;
            other.transform.rotation = antLoop.rotation;
            other.GetComponent<NavMeshAgent>().enabled = true;

        }else if (other.gameObject.CompareTag("Player"))
        {
            character.transform.position = characterSpawn.position;
            gun.transform.position = characterSpawn.position;
            ant.GetComponent<NavMeshAgent>().enabled = false;
            ant.transform.position = antSpawn.position;
            ant.GetComponent<NavMeshAgent>().enabled = true;
        
            sound.Play();


        } 

    }
}
