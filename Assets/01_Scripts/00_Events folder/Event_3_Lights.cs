using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class Event_3_Object : MonoBehaviour
{
    public GameObject lightsToTurnOn;
    public GameObject redDot;
    public bool isTrigger;
    public TextoInteractuarScript textoInteractuarScript;
    public EventManager eventManager;
    [SerializeField]private BoxCollider objectCollider;

    
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
          
            lightsToTurnOn.SetActive(true);
            redDot.SetActive(false);

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
