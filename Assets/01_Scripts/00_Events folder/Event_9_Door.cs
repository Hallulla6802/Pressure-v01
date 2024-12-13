using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using static EventManager;

public class Event_9_Door : MonoBehaviour
{
    public EventManager eventManager;
    public Outline objOutline;
    private ObjectivesManager objMan;
    public GameObject lastCutsceneCollider;
    public string objectText;
    //[Space]
    //public string localizationKeyforEvent9 = "";
    //private LocalizedString currentLocalizedText;



    private void Awake()
    {
        eventManager = FindObjectOfType<EventManager>();
        objMan = FindObjectOfType<ObjectivesManager>();

    }

    //private void Start()
    //{
    //    currentLocalizedText = new LocalizedString();
    //    currentLocalizedText.TableReference = "Table1";
    //    currentLocalizedText.TableEntryReference = localizationKeyforEvent9;
    //}

    //public void RefreshEvent9Text()
    //{
    //    currentLocalizedText = new LocalizedString
    //    {
    //        TableReference = "Table1",
    //        TableEntryReference = localizationKeyforEvent9
    //    };
    //}


    public void CerrarPuertaEvent9()
    {
       
           
            eventManager.currentEvent = EventsToTrigger.Final12;
        
            objOutline.enabled = false;
           


            objMan.currentStates = ObjectivesManager.ObjectiveStates.UploadProject;
            
        
    }

   
}
