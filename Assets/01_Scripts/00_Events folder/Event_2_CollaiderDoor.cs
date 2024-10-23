using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class Event_2_CollaiderDoor : MonoBehaviour
{
    public EventManager eventManager;
    public TextoInteractuarScript textoInteractuarScript;
    public BoxCollider objectCollider;
    public AudioSource knocksound;
    public bool isTrigger;

    private ObjectivesManager objMan;

    private void Awake()
    {
        objectCollider = GetComponent<BoxCollider>();
        eventManager = FindObjectOfType<EventManager>();
        textoInteractuarScript = FindObjectOfType<TextoInteractuarScript>();
        objectCollider.enabled = true;

        objMan = FindObjectOfType<ObjectivesManager>();
    }

private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        //Debug.Log("PlayerHasCollided");
        isTrigger = true;
        textoInteractuarScript.AbrirTextoInteractuar();

        

    }

}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isTrigger)
        {
            knocksound.Stop();
            objectCollider.enabled = false;
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
