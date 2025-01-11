using Unity.Multiplayer.Center.Common;
using UnityEngine;

public class startFollow : MonoBehaviour
{
    public bool startBridge = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter()
    {
        startBridge = true;
    }
}
