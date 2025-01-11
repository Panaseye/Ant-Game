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
    

   void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("ammo"))
        {
            character.transform.position = characterSpawn.position;
            gun.transform.position = gunSpawn.position;

        } else if (other.gameObject.CompareTag("ammo"))
        {
            Destroy(other.gameObject);
        }
       

    }
}
