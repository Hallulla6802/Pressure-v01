using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class Event_1_CollaiderMicrondas : MonoBehaviour
{

    public AudioSource microndasSound;
    public TextoInteractuarScript textoInteractuarScript;
    public EventManager eventManager;
    public BoxCollider objectCollider;
    public bool isTrigger;

    private void Awake()
    {
        objectCollider = GetComponent<BoxCollider>();
        eventManager = FindObjectOfType<EventManager>();
        objectCollider.enabled = true;
        textoInteractuarScript = FindObjectOfType<TextoInteractuarScript>();
    }

  

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTrigger = true;
            textoInteractuarScript.AbrirTextoInteractuar();

           


       
          
           
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isTrigger)
        {

            microndasSound.Stop();
            objectCollider.enabled = false;
            eventManager.currentEvent = EventsToTrigger.None;
            textoInteractuarScript.CerrarTextoInteractuar();
            isTrigger = false;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTrigger = false;
            textoInteractuarScript.CerrarTextoInteractuar();
        }
    }
}


