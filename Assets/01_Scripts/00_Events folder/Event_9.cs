using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_9 : MonoBehaviour
{
    public AudioSource doorSound;
    public GameObject doorTrigger;

    private BoxCollider event9Collider;

    private void Awake()
    {
        event9Collider = GetComponent<BoxCollider>();
        doorTrigger.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorSound.Play();

            event9Collider.enabled = false;
            doorTrigger.SetActive(true);
        }
    }
}
