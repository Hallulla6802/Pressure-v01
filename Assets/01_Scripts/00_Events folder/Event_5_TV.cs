using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class Event_5_TV : MonoBehaviour
{
    public AudioSource tvSound;
    public TextoInteractuarScript textoInteractuarScript;
    private BoxCollider event5Collider;
    public EventManager eventManager;
    public bool isTrigger;

    private ObjectivesManager objMan;
    private void Awake()
    {
        textoInteractuarScript = FindObjectOfType<TextoInteractuarScript>();
        event5Collider = GetComponent<BoxCollider>();
        objMan = FindObjectOfType<ObjectivesManager>();
        eventManager = FindObjectOfType<EventManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isTrigger = true;
            textoInteractuarScript.AbrirTextoInteractuar();
        }
    }

    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.E) && isTrigger)
       {
            tvSound.Stop();
            event5Collider.enabled = false;
            eventManager.currentEvent = EventsToTrigger.None;
            textoInteractuarScript.CerrarTextoInteractuar();
            isTrigger = false;

            objMan.currentStates = ObjectivesManager.ObjectiveStates.GoToThePC;
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
