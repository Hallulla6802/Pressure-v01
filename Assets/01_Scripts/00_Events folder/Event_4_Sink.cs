using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class Event_4_Sink : MonoBehaviour
{
    public AudioSource waterSound;
    public AudioSource waterStop;

    public Evento_10 evento_10;
    public EventManager eventManager;
   
    public TextoInteractuarScript textoInteractuarScript;
   
    private ObjectivesManager objMan;
    public string objectText;

    private void Awake()
    {
     
        eventManager = FindObjectOfType<EventManager>();
        textoInteractuarScript = FindObjectOfType<TextoInteractuarScript>();
        objMan = FindObjectOfType<ObjectivesManager>();
    }

  

    public void CerrarLavamanos()
    {
        
        waterSound.Stop();
        waterStop.Play();

        evento_10.ShadowEvent4();
        eventManager.currentEvent = EventsToTrigger.None;
        textoInteractuarScript.CerrarTextoInteractuar();

        objMan.currentStates = ObjectivesManager.ObjectiveStates.GoToThePC;
        
    }

  
}
