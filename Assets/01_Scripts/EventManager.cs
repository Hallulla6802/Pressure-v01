using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.ProBuilder.Shapes;

public class EventManager : MonoBehaviour
{
    public ClockScript clockscript;
    public MecanographicScript mecanographicscript;
    public ComputerInteraction computerInteraction;
    public Evento_10 evento_10;
    public GameObject pcScreen;

    private EventsToTrigger lastEvent;

    public float timeEvent1;
    public float timeEvent1Limit;
    public bool event1Trigged = false;

    public float timeEvent2;
    public float timeEvent2Limit;
    public bool eventTrigged2 = false;

    public float timeEvent3;
    public float timeEvent3Limit;
    public bool eventTrigged3 = false;

    public float timeEvent4;
    public float timeEvent4Limit;
    public bool eventTrigged4 = false;

    public float timeEvent5;
    public float timeEvent5Limit;
    public bool eventTrigged5 = false;

    public float timeEvent6;
    public float timeEvent6Limit;
    public bool eventTrigged6 = false;

 

    public float timeEvent8;
    public float timeEvent8Limit;
    public bool eventTrigged8 = false;

    public float timeEvent9;
    public float timeEvent9Limit;
    public bool eventTrigged9 = false;

    
    public enum EventsToTrigger
    {
        None,
        Event1,
        Event2,
        Event3,
        Event4,
        Event5,
        Event6,
        Event7,
        Event8,
        Event9,
        Event10
    }

    [Space]
    public EventsToTrigger currentEvent;
    [Space]
    [Header("EMPTY COLLIDERS FOR EVENTS")]
    [Space]
    // Para añadir eventos haga un gameobject 
    //que tenga nombre del evento y su numero, 
    //a este gameobject añadale un collider trigger y un script del evento en si.

    public GameObject event1Collider;
    public GameObject event2Collider;
    public GameObject event3Collider;
    public GameObject event4Collider;
    public GameObject event5Collider;
    public GameObject event6Collider;
   
    public GameObject event8Collider;
    public GameObject event9Collider;

    public GameObject colaiderMicrondas;
    //public Gameobject event10Collider;


    public ObjectivesManager objMan;

    private void Awake()
    {
        clockscript = FindObjectOfType<ClockScript>();
        mecanographicscript = FindObjectOfType<MecanographicScript>();
        computerInteraction = FindObjectOfType<ComputerInteraction>();
        evento_10 = FindObjectOfType<Evento_10>();
        
    }


    //Añada los eventos a start y update para que
    //empiezen escondidos y se vallan triggereando por caso
    private void Start()
    {
        objMan = FindObjectOfType<ObjectivesManager>();

        lastEvent = EventsToTrigger.None;
        colaiderMicrondas.SetActive(false);
        event1Collider.SetActive(false);
        event2Collider.SetActive(false);
        event3Collider.SetActive(false);
        event4Collider.SetActive(false);
        event5Collider.SetActive(false);
        event6Collider.SetActive(false);
        
        event8Collider.SetActive(false);
        event9Collider.SetActive(false);
    }
    private void Update()
    {
        if (mecanographicscript.currentAmount == mecanographicscript.maximumMecanoAmout)
        {
            clockscript.timeScale = 10f;
        }

        if (!event1Trigged && clockscript.timeInMinutes >= timeEvent1 && clockscript.timeInMinutes <= timeEvent1Limit)
        {

            if (mecanographicscript.currentAmount < mecanographicscript.minimumMecanoAmount)
            {

                clockscript.frezzeTime = true;

            }
            if (mecanographicscript.currentAmount >= mecanographicscript.minimumMecanoAmount)
            {
                currentEvent = EventsToTrigger.Event1;
                objMan.currentStates = ObjectivesManager.ObjectiveStates.InvestigateMicrowave;
                event1Trigged = true;
                

            }

        }
        if (!eventTrigged2 && clockscript.timeInMinutes >= timeEvent2 && clockscript.timeInMinutes <= timeEvent2Limit)
        {


            if (mecanographicscript.currentAmount < mecanographicscript.minimumMecanoAmount)
            {

                clockscript.frezzeTime = true;

            }
            if (mecanographicscript.currentAmount >= mecanographicscript.minimumMecanoAmount)
            {
                // Debug.Log("Se gatilla el evento2 Door Knock");
                currentEvent = EventsToTrigger.Event2;
                objMan.currentStates = ObjectivesManager.ObjectiveStates.InvestigateDoorKnocking;
                eventTrigged2 = true;

            }
            
        }

        if (!eventTrigged3 && clockscript.timeInMinutes >= timeEvent3 && clockscript.timeInMinutes <= timeEvent3Limit)
        {

            if (mecanographicscript.currentAmount < mecanographicscript.minimumMecanoAmount)
            {

                clockscript.frezzeTime = true;

            }
            if (mecanographicscript.currentAmount >= mecanographicscript.minimumMecanoAmount)
            {
                //Debug.Log("Se gatilla el evento3 Lights");
                currentEvent = EventsToTrigger.Event3;
                objMan.currentStates = ObjectivesManager.ObjectiveStates.FixTheLights;
                eventTrigged3 = true;
            }
           
        }

        if (!eventTrigged4 && clockscript.timeInMinutes >= timeEvent4 && clockscript.timeInMinutes <= timeEvent4Limit)
        {
            if (mecanographicscript.currentAmount < mecanographicscript.minimumMecanoAmount)
            {

                clockscript.frezzeTime = true;

            }
            if (mecanographicscript.currentAmount >= mecanographicscript.minimumMecanoAmount)
            {
                //Debug.Log("Se gatilla el evento4 Water");
                currentEvent = EventsToTrigger.Event4;
                objMan.currentStates = ObjectivesManager.ObjectiveStates.TurnOffTheWater;
                eventTrigged4 = true;
            }
           
        }

        if (!eventTrigged5 && clockscript.timeInMinutes >= timeEvent5 && clockscript.timeInMinutes <= timeEvent5Limit)
        {
            if (mecanographicscript.currentAmount < mecanographicscript.minimumMecanoAmount)
            {

                clockscript.frezzeTime = true;

            }
            if (mecanographicscript.currentAmount >= mecanographicscript.minimumMecanoAmount)
            {
                //Debug.Log("Se gatilla el evento5 TV");
                currentEvent = EventsToTrigger.Event5;
                objMan.currentStates = ObjectivesManager.ObjectiveStates.TurnOffTheTV;
                eventTrigged5 = true;
            }

        }

        if (!eventTrigged6 && clockscript.timeInMinutes >= timeEvent6 && clockscript.timeInMinutes <= timeEvent6Limit)
        {
            if (mecanographicscript.currentAmount < mecanographicscript.minimumMecanoAmount)
            {

                clockscript.frezzeTime = true;

            }
            if (mecanographicscript.currentAmount >= mecanographicscript.minimumMecanoAmount)
            {
                //Debug.Log("Se gatilla el evento6 Radio Fix");
                currentEvent = EventsToTrigger.Event6;
                objMan.currentStates = ObjectivesManager.ObjectiveStates.FixTheRadio;
                eventTrigged6 = true;
            }

        }

        if (!eventTrigged8 && clockscript.timeInMinutes >= timeEvent8 && clockscript.timeInMinutes <= timeEvent8Limit)
        {
            if (mecanographicscript.currentAmount < mecanographicscript.minimumMecanoAmount)
            {

                clockscript.frezzeTime = true;

            }
            if (mecanographicscript.currentAmount >= mecanographicscript.minimumMecanoAmount)
            {
                //Debug.Log("Se gatilla el evento8 Steps");
                currentEvent = EventsToTrigger.Event8;
                
                eventTrigged8 = true;
            }

        }


        if (!eventTrigged9 && clockscript.timeInMinutes >= timeEvent9 && clockscript.timeInMinutes <= timeEvent9Limit)
        {
            if (mecanographicscript.currentAmount < mecanographicscript.minimumMecanoAmount)
            {

                clockscript.frezzeTime = true;

            }
            if (mecanographicscript.currentAmount >= mecanographicscript.minimumMecanoAmount)
            {
                //Debug.Log("Se gatilla el evento8 Steps");
                currentEvent = EventsToTrigger.Event9;

                eventTrigged9 = true;
            }

        }



        if (currentEvent != lastEvent)
        {
            switch (currentEvent)
            {
                case EventsToTrigger.None:

                    // Debug.Log("Nothing is happening");

                    clockscript.frezzeTime = false;
                    pcScreen.SetActive(true);
                    event1Collider.SetActive(false);
                    event2Collider.SetActive(false);
                    event3Collider.SetActive(false);
                    event4Collider.SetActive(false);
                    event5Collider.SetActive(false);
                    event6Collider.SetActive(false);
                    
                    event8Collider.SetActive(false);
                    event9Collider.SetActive(false);
                    colaiderMicrondas.SetActive(false);

                    break;

                case EventsToTrigger.Event1:

                    //Debug.Log("Event 1 is triggered");
                    evento_10.ShadowEvent1();
                    computerInteraction.ExitInteraction();
                    clockscript.frezzeTime = true;
                    AumentoMinMaxCurrentyArregloTimeScale();
                    event1Collider.SetActive(true);
                    event2Collider.SetActive(false);
                    event3Collider.SetActive(false);
                    event4Collider.SetActive(false);
                    event5Collider.SetActive(false);
                    event6Collider.SetActive(false);
                    
                    event8Collider.SetActive(false);
                    event9Collider.SetActive(false);
                    colaiderMicrondas.SetActive(true);


                    break;

                case EventsToTrigger.Event2:

                    //Debug.Log("Event 2 is triggered");
                    evento_10.ShadowEvent2();
                    computerInteraction.ExitInteraction();
                    clockscript.frezzeTime = true;
                    AumentoMinMaxCurrentyArregloTimeScale();
                    event1Collider.SetActive(false);
                    event2Collider.SetActive(true);
                    event3Collider.SetActive(false);
                    event4Collider.SetActive(false);
                    event5Collider.SetActive(false);
                    event6Collider.SetActive(false);
                    
                    event8Collider.SetActive(false);
                    colaiderMicrondas.SetActive(false);

                    break;

                case EventsToTrigger.Event3:

                    //Debug.Log("Event 3 is triggered");
                    evento_10.ShadowEvent3();
                    event3Collider.SetActive(true);
                    computerInteraction.ExitInteraction();
                    clockscript.frezzeTime = true;
                    AumentoMinMaxCurrentyArregloTimeScale();
                    event1Collider.SetActive(false);
                    event2Collider.SetActive(false);
                    
                    event4Collider.SetActive(false);
                    event5Collider.SetActive(false);
                    event6Collider.SetActive(false);
                    
                    event8Collider.SetActive(false);
                    event9Collider.SetActive(false);
                    colaiderMicrondas.SetActive(false);

                    break;

                case EventsToTrigger.Event4:

                    //Debug.Log("Event 4 is triggered");
                    evento_10.ShadowEvent4();
                    computerInteraction.ExitInteraction();
                    clockscript.frezzeTime = true;
                    AumentoMinMaxCurrentyArregloTimeScale();
                    event1Collider.SetActive(false);
                    event2Collider.SetActive(false);
                    event3Collider.SetActive(false);
                    event4Collider.SetActive(true);
                    event5Collider.SetActive(false);
                    
                    event8Collider.SetActive(false);
                    event9Collider.SetActive(false);
                    colaiderMicrondas.SetActive(false);

                    break;

                case EventsToTrigger.Event5:

                    //Debug.Log("Event 5 is triggered");
                    evento_10.ShadowEvent5();
                    clockscript.frezzeTime = true;
                    AumentoMinMaxCurrentyArregloTimeScale();
                    computerInteraction.ExitInteraction();
                    event1Collider.SetActive(false);
                    event2Collider.SetActive(false);
                    event3Collider.SetActive(false);
                    event4Collider.SetActive(false);
                    event5Collider.SetActive(true);
                    event6Collider.SetActive(false);
                    
                    event8Collider.SetActive(false);
                    event9Collider.SetActive(false);
                    colaiderMicrondas.SetActive(false);

                    break;

                case EventsToTrigger.Event6:

                    //Debug.Log("Event 6 is triggered");
                    evento_10.ShadowEvent6();
                    clockscript.frezzeTime = true;
                    AumentoMinMaxCurrentyArregloTimeScale();
                    computerInteraction.ExitInteraction();
                    event1Collider.SetActive(false);
                    event2Collider.SetActive(false);
                    event3Collider.SetActive(false);
                    event4Collider.SetActive(false);
                    event5Collider.SetActive(false);
                    event6Collider.SetActive(true);
                    
                    event8Collider.SetActive(false);
                    event9Collider.SetActive(false);
                    colaiderMicrondas.SetActive(false);

                    break;

                

                case EventsToTrigger.Event8:

                    //Debug.Log("Event 8 is triggered");

                    clockscript.frezzeTime = true;
                    computerInteraction.ExitInteraction();
                    AumentoMinMaxCurrentyArregloTimeScale();
                    event1Collider.SetActive(false);
                    event2Collider.SetActive(false);
                    event3Collider.SetActive(false);
                    event4Collider.SetActive(false);
                    event5Collider.SetActive(false);
                    event6Collider.SetActive(false);
                    
                    event8Collider.SetActive(true);
                    event9Collider.SetActive(false);
                    colaiderMicrondas.SetActive(false);

                    break;

                case EventsToTrigger.Event9:

                    //Debug.Log("Event 9 is triggered");
                    evento_10.ShadowEvent9();
                    clockscript.frezzeTime = true;
                    AumentoMinMaxCurrentyArregloTimeScale();
                    computerInteraction.ExitInteraction();
                    event1Collider.SetActive(false);
                    event2Collider.SetActive(false);
                    event3Collider.SetActive(false);
                    event4Collider.SetActive(false);
                    event5Collider.SetActive(false);
                    event6Collider.SetActive(false);
                    
                    event8Collider.SetActive(false);
                    event9Collider.SetActive(true);
                    colaiderMicrondas.SetActive(false);

                    break;

               
            }

            lastEvent = currentEvent;
        }
        
    }

    void AumentoMinMaxCurrentyArregloTimeScale()
    {
        clockscript.timeScale = 1f;
        mecanographicscript.minimumMecanoAmount += 3;
        mecanographicscript.maximumMecanoAmout += 4;
    }

}
