using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class Event_1_CollaiderMicrondas : MonoBehaviour
{



    public EventManager eventManager;
    public BoxCollider objectCollider;

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



            objectCollider.enabled = false;
            eventManager.currentEvent = EventsToTrigger.None;
          
           
        }

    }
}


