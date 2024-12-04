using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class Event_5_TV : MonoBehaviour
{
    public AudioSource tvSound;
    public TextoInteractuarScript textoInteractuarScript;
    
    public EventManager eventManager;
    
    public GameObject tvObj;
  
    public string objectText;

    private ObjectivesManager objMan;
    private void Awake()
    {
        textoInteractuarScript = FindObjectOfType<TextoInteractuarScript>();
       
        objMan = FindObjectOfType<ObjectivesManager>();
        eventManager = FindObjectOfType<EventManager>();
    }

  

    public void ApagarTele()
    {
       
            tvSound.Stop();
          
            eventManager.currentEvent = EventsToTrigger.None;
            textoInteractuarScript.CerrarTextoInteractuar();
          
            tvObj.SetActive(false);
            objMan.currentStates = ObjectivesManager.ObjectiveStates.GoToThePC;
        
    }

    
}
