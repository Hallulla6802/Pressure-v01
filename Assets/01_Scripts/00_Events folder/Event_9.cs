using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_9 : MonoBehaviour
{
    public AudioSource doorSound;
    public GameObject doorTrigger;
    public PrincipalDoorScript principaldoorscript;

    private BoxCollider event9Collider;

    private void Awake()
    {
        event9Collider = GetComponent<BoxCollider>();
        principaldoorscript = FindObjectOfType<PrincipalDoorScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorSound.Play();
            principaldoorscript.OpenDoorEvent9();
            event9Collider.enabled = false;
            
        }
    }
}
