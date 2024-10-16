using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_4_Sink : MonoBehaviour
{
    public AudioSource waterSound;

    private BoxCollider event4Collider;

    private void Awake()
    {
        event4Collider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            waterSound.Stop();
            event4Collider.enabled = false;
        }
    }
}
