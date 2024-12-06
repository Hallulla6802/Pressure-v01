using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class Event_9_Door : MonoBehaviour
{
   
    
    public EventManager eventManager;
    public Outline objOutline;
    private ObjectivesManager objMan;
    public GameObject lastCutsceneCollider;
   public string objectText;

    private void Awake()
    {
       
        
        eventManager = FindObjectOfType<EventManager>();
        objMan = FindObjectOfType<ObjectivesManager>();

    }

    
    public void CerrarPuertaEvent9()
    {
       
           
            eventManager.currentEvent = EventsToTrigger.Final12;
        
            objOutline.enabled = false;
           


            objMan.currentStates = ObjectivesManager.ObjectiveStates.UploadProject;
            
        
    }

   
}
