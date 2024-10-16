using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_9_Door : MonoBehaviour
{
    private BoxCollider event5Collider;

    private void Awake()
    {
        event5Collider = GetComponent<BoxCollider>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Has closed Door");

            event5Collider.enabled = false;
        }
    }
}
