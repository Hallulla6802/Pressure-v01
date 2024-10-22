using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class Event_1 : MonoBehaviour
{

    public AudioSource microndasSound;
    private BoxCollider event1collider;

    public EventManager eventManager;

    private void Awake()
    {
        event1collider = GetComponent<BoxCollider>();
        
        eventManager = FindObjectOfType<EventManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            microndasSound.Play();
            event1collider.enabled = false;
                
            
        }
    }

   
}