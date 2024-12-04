using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class Event_6_RadioTrigger : MonoBehaviour
{
    public AudioSource animalSounds;
   
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

    

    public void ApagarRadio()
    {
        
            animalSounds.Stop();
          
            eventManager.currentEvent = EventsToTrigger.None;
            textoInteractuarScript.CerrarTextoInteractuar();
           

            objMan.currentStates = ObjectivesManager.ObjectiveStates.GoToThePC;
        
    }

  
}
