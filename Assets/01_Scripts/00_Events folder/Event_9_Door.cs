using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class Event_9_Door : MonoBehaviour
{
    private BoxCollider event5Collider;
    public bool isTrigger;
    public TextoInteractuarScript textoInteractuarScript;
    public EventManager eventManager;
    private ObjectivesManager objMan;
    public GameObject lastCutsceneCollider;
   

    private void Awake()
    {
        event5Collider = GetComponent<BoxCollider>();
        textoInteractuarScript = FindObjectOfType<TextoInteractuarScript>();
        eventManager = FindObjectOfType<EventManager>();
        objMan = FindObjectOfType<ObjectivesManager>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player Has closed Door");
            isTrigger = true;
            textoInteractuarScript.AbrirTextoInteractuar();
           

        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isTrigger)
        {
           
            eventManager.currentEvent = EventsToTrigger.Final;
            textoInteractuarScript.CerrarTextoInteractuar();
            event5Collider.enabled = false;
            isTrigger = false;

            objMan.currentStates = ObjectivesManager.ObjectiveStates.UploadProject;
            
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
