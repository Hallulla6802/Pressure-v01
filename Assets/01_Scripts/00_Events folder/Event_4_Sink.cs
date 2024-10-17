using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class Event_4_Sink : MonoBehaviour
{
    public AudioSource waterSound;

    private BoxCollider event4Collider;
    public EventManager eventManager;

    private void Awake()
    {
        event4Collider = GetComponent<BoxCollider>();
        eventManager = FindObjectOfType<EventManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            waterSound.Stop();
            event4Collider.enabled = false;
            eventManager.currentEvent = EventsToTrigger.None;
        }
    }
}
