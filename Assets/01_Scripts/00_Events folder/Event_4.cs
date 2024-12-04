using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_4 : MonoBehaviour
{
    public AudioSource waterSound;


    private BoxCollider event4Collider;
   

    private void Awake()
    {
        event4Collider = GetComponent<BoxCollider>();
    

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            waterSound.Play();

            event4Collider.enabled = false;
           
        }
    }
}
