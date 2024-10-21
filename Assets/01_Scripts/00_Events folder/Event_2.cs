using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class Event_2 : MonoBehaviour
{
  

    private BoxCollider event2Collider;
    public AudioSource knocksound;
    public EventManager eventManager;

    private void Awake()
    {
        event2Collider = GetComponent<BoxCollider>();
        eventManager = FindObjectOfType<EventManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            knocksound.Play();
            event2Collider.enabled = false;
               
            
        }
    }

  
}
