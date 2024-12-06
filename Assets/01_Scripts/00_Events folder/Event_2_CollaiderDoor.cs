using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class Event_2_CollaiderDoor : MonoBehaviour
{
    public EventManager eventManager;
   
   
    public AudioSource knocksound;
    public bool isTrigger;
    public Outline objOutline;
    public ObjectivesManager objMan;

    private void Awake()
    {
        
        eventManager = FindObjectOfType<EventManager>();

       
        objMan = FindObjectOfType<ObjectivesManager>();
    }

    public void InteractuarConLaPuertaParaResolverElEvento2()
    {
        knocksound.Stop();
       
        eventManager.currentEvent = EventsToTrigger.None;
   
        objOutline.enabled = false;
        isTrigger = false;
        objMan.currentStates = ObjectivesManager.ObjectiveStates.GoToThePC;
    }






  
}
