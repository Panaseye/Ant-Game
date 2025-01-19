using Unity.Multiplayer.Center.Common;
using UnityEngine;

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
            other.transform.position = antLoop.position;
            other.transform.rotation = antLoop.rotation;

        }else if (other.gameObject.CompareTag("Player"))
        {
            character.transform.position = characterSpawn.position;
            gun.transform.position = gunSpawn.position;
            ant.transform.position = antSpawn.position;
            startFollow.startBridge = false;
            sound.Play();


        } 

    }
}
