using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class Event_1_CollaiderMicrondas : MonoBehaviour
{

    public AudioSource microndasSound;
    public TextoInteractuarScript textoInteractuarScript;
    public EventManager eventManager;
    public Animator plate_Animator;
    private ObjectivesManager objMan;
    public AudioSource microwaveAudio;
    public GameObject microwaveLight;

    private void Awake()
    {
       
        GameObject microwaveObject = GameObject.Find("Microwave Button");

        if (microwaveObject != null)
        {
            microwaveAudio = microwaveObject.GetComponent<AudioSource>();
        }
     
        eventManager = FindObjectOfType<EventManager>();
      
        textoInteractuarScript = FindObjectOfType<TextoInteractuarScript>();
        objMan = FindObjectOfType<ObjectivesManager>();
    }

  

   
  

    public void ApagarMicroondas()
    {
        
        

            microndasSound.Stop();
            microwaveAudio.Play();
            microwaveLight.SetActive(false);
         
            eventManager.currentEvent = EventsToTrigger.None;
            textoInteractuarScript.CerrarTextoInteractuar();
        
            plate_Animator.speed = 0;

            objMan.currentStates = ObjectivesManager.ObjectiveStates.GoToThePC;
        
    }



}


