using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class Event_2_CollaiderDoor : MonoBehaviour
{
    public EventManager eventManager;
    public BoxCollider objectCollider;
    public AudioSource knocksound;

    private void Awake()
{
    objectCollider = GetComponent<BoxCollider>();
    eventManager = FindObjectOfType<EventManager>();
    objectCollider.enabled = true;
}

private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        Debug.Log("PlayerHasCollided");


        knocksound.Stop();
        objectCollider.enabled = false;
        eventManager.currentEvent = EventsToTrigger.None;


    }

}
}
