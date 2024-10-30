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
    public Outline objOutline;
    
    private ObjectivesManager objMan;
    public AudioSource botonSonido;


    private void Awake()
    {

        GameObject botonObject = GameObject.Find("Switch");

        if (botonObject != null)
        {
            botonSonido = botonObject.GetComponent<AudioSource>();
        }
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
            objOutline.enabled = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isTrigger)
        {
            botonSonido.Play();
            lightsToTurnOn.SetActive(true);
            redDot.SetActive(false);

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
