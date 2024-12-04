using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class Event_3_Object : MonoBehaviour
{
    public GameObject lightsToTurnOn;
    public GameObject redDot;
    
    public TextoInteractuarScript textoInteractuarScript;
    public EventManager eventManager;
    //[SerializeField]private BoxCollider objectCollider;
    //public Outline objOutline;
    
    private ObjectivesManager objMan;
    public AudioSource botonSonido;
    public string objectText;


    private void Awake()
    {

        GameObject botonObject = GameObject.Find("Switch");

        if (botonObject != null)
        {
            botonSonido = botonObject.GetComponent<AudioSource>();
        }
        
        eventManager = FindObjectOfType<EventManager>();
        textoInteractuarScript = FindObjectOfType<TextoInteractuarScript>();
    

        objMan = FindObjectOfType<ObjectivesManager>();
    }



  public void PrenderLuces()
  {

        botonSonido.Play();
        lightsToTurnOn.SetActive(true);
        redDot.SetActive(false);
        
        eventManager.currentEvent = EventsToTrigger.None;
        textoInteractuarScript.CerrarTextoInteractuar();
      
        objMan.currentStates = ObjectivesManager.ObjectiveStates.GoToThePC;
      

  }
  



}
