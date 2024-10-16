using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_3_Object : MonoBehaviour
{
    private Event_3 event3script;
    private BoxCollider objectCollider;

    private void Awake()
    {
        event3script = FindObjectOfType<Event_3>();
        objectCollider = GetComponent<BoxCollider>();

        objectCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("PlayerHasCollided");

            event3script.lightempty.SetActive(true);
            event3script.redDotForOutside.SetActive(false);

            event3script.lightsFixed = true;
            objectCollider.enabled = false;




        }
    }
}
