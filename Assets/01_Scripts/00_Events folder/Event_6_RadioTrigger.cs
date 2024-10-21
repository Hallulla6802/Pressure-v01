using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class Event_6_RadioTrigger : MonoBehaviour
{
    public AudioSource animalSounds;

    private BoxCollider event6Collider;
    public EventManager eventManager;

    private void Awake()
    {
        event6Collider = GetComponent<BoxCollider>();
        eventManager = FindObjectOfType<EventManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animalSounds.Stop();
            event6Collider.enabled = false;
            eventManager.currentEvent = EventsToTrigger.None;
        }
    }
}
