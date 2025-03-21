using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class Event_1 : MonoBehaviour
{

    public AudioSource microndasSound;
    private BoxCollider event1collider;
    public GameObject microwaveLight;
    public EventManager eventManager;
    public Animator plate_Animator;

    private void Awake()
    {
        event1collider = GetComponent<BoxCollider>();
        
        eventManager = FindObjectOfType<EventManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            microwaveLight.SetActive(true);
            microndasSound.Play();
            event1collider.enabled = false;
            plate_Animator.SetTrigger("Spin");
        }
    }

   
}