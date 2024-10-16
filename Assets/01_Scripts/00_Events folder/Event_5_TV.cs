using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_5_TV : MonoBehaviour
{
    public AudioSource tvSound;

    private BoxCollider event5Collider;

    private void Awake()
    {
        event5Collider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            tvSound.Stop();
            event5Collider.enabled = false;
        }
    }
}
