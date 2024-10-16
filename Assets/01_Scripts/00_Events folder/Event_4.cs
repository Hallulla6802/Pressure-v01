using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_4 : MonoBehaviour
{
    public AudioSource waterSound;
    public GameObject sinkTrigger;

    private BoxCollider event4Collider;

    private void Awake()
    {
        event4Collider = GetComponent<BoxCollider>();
        sinkTrigger.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            waterSound.Play();

            event4Collider.enabled = false;
            sinkTrigger.SetActive(true);
        }
    }
}
