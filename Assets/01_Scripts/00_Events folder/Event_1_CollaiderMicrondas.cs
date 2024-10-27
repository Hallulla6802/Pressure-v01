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
    public Outline objOutline;
    private ObjectivesManager objMan;

    private void Awake()
    {
        objectCollider = GetComponent<BoxCollider>();
        eventManager = FindObjectOfType<EventManager>();
        objectCollider.enabled = true;
        textoInteractuarScript = FindObjectOfType<TextoInteractuarScript>();
        objMan = FindObjectOfType<ObjectivesManager>();
    }

  

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTrigger = true;
            textoInteractuarScript.AbrirTextoInteractuar();
            objOutline.enabled = true;
        
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
            objOutline.enabled = false;
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
            objOutline.enabled = false;
        }
    }
}


