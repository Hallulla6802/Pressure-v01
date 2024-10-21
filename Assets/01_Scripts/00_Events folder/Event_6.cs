using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_6 : MonoBehaviour
{

    public AudioSource animalSounds;
    public EventManager eventManager;
    private BoxCollider event6Collider;

    private void Awake()
    {
        event6Collider = GetComponent<BoxCollider>();
        eventManager = FindObjectOfType<EventManager>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            animalSounds.Play();
            event6Collider.enabled = false;
           
        }
    }
}

