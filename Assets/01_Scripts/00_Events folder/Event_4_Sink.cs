using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class Event_4_Sink : MonoBehaviour
{
    public AudioSource waterSound;

    private BoxCollider event4Collider;
    public EventManager eventManager;
    public bool isTrigger;
    public TextoInteractuarScript textoInteractuarScript;

    private ObjectivesManager objMan;

    private void Awake()
    {
        event4Collider = GetComponent<BoxCollider>();
        eventManager = FindObjectOfType<EventManager>();
        textoInteractuarScript = FindObjectOfType<TextoInteractuarScript>();
        objMan = FindObjectOfType<ObjectivesManager>();
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
            waterSound.Stop();
            event4Collider.enabled = false;
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
