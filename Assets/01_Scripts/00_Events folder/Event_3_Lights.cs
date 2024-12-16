using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class Event_3_Object : MonoBehaviour
{
    public GameObject lightsToTurnOn;
    public GameObject redDot;
    public Material M_lightbulb;
    public Material M_bulb;
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
        EnableEmission(M_bulb, new Color(1.6f, 1.4f, 1f));
        EnableEmission(M_lightbulb, new Color(1.6f, 1.3f, 1f));
        redDot.SetActive(false);
        
        eventManager.currentEvent = EventsToTrigger.None;
        textoInteractuarScript.CerrarTextoInteractuar();
      
        objMan.currentStates = ObjectivesManager.ObjectiveStates.GoToThePC;

  }
  void EnableEmission(Material material, Color emissionColor)
    {
        if (material.HasProperty("_EmissionColor"))
        {
            material.SetColor("_EmissionColor", emissionColor);
            material.EnableKeyword("_EMISSION");
        }
    }
}
