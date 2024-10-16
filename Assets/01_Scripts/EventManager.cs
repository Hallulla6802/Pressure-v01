using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.ProBuilder.Shapes;

public class EventManager : MonoBehaviour
{
    public ClockScript clockscript;
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

    public float timeEvent7;
    public float timeEvent7Limit;
    public bool eventTrigged7 = false;

    public float timeEvent8;
    public float timeEvent8Limit;
    public bool eventTrigged8 = false;

    public float timeEvent9;
    public float timeEvent9Limit;
    public bool eventTrigged9 = false;

    public float timeEvent10;
    public float timeEvent10Limit;
    public bool eventTrigged10 = false;
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
    //public Gameobject event6Collider;
    public GameObject event7Collider;
    public GameObject event8Collider;
    public GameObject event9Collider;
    //public Gameobject event10Collider;

    private void Awake()
    {
        clockscript = FindObjectOfType<ClockScript>();
    }


    //Añada los eventos a start y update para que
    //empiezen escondidos y se vallan triggereando por caso
    private void Start()
    {
        event1Collider.SetActive(false);
        event2Collider.SetActive(false);
        event3Collider.SetActive(false);
        event4Collider.SetActive(false);
        event5Collider.SetActive(false);
        event7Collider.SetActive(false);
        event8Collider.SetActive(false);
        event9Collider.SetActive(false);
    }
    private void Update()
    {


        if (!event1Trigged && clockscript.timeInMinutes >= timeEvent1 && clockscript.timeInMinutes <= timeEvent1Limit)
        {
            //Debug.Log("Se gatilla el evento1");
            currentEvent = EventsToTrigger.Event1;
            event1Trigged = true;
        }

        if (!eventTrigged2 && clockscript.timeInMinutes >= timeEvent2 && clockscript.timeInMinutes <= timeEvent2Limit)
        {
            Debug.Log("Se gatilla el evento2");
            currentEvent = EventsToTrigger.Event2;
            event1Trigged = true;
        }




        switch (currentEvent) 
        {
            case EventsToTrigger.None:

               // Debug.Log("Nothing is happening");

                clockscript.frezzeTime = false;

                event1Collider.SetActive(false);
                event2Collider.SetActive(false);
                event3Collider.SetActive(false);
                event4Collider.SetActive(false);
                event5Collider.SetActive(false);
                event7Collider.SetActive(false);
                event8Collider.SetActive(false);
                event9Collider.SetActive(false);

                break;

            case EventsToTrigger.Event1:

                //Debug.Log("Event 1 is triggered");

                clockscript.frezzeTime = true;

                event1Collider.SetActive(true);
                event2Collider.SetActive(false);
                event3Collider.SetActive(false);
                event4Collider.SetActive(false);
                event5Collider.SetActive(false);
                event7Collider.SetActive(false);
                event8Collider.SetActive(false);
                event9Collider.SetActive(false);


                break; 
            
            case EventsToTrigger.Event2:

                //Debug.Log("Event 2 is triggered");

                clockscript.frezzeTime = true;

                event1Collider.SetActive(false);
                event2Collider.SetActive(true);
                event3Collider.SetActive(false);
                event4Collider.SetActive(false);
                event5Collider.SetActive(false);
                event7Collider.SetActive(false);
                event8Collider.SetActive(false);

                break;

            case EventsToTrigger.Event3:

                //Debug.Log("Event 3 is triggered");

                clockscript.frezzeTime = true;

                event1Collider.SetActive(false);
                event2Collider.SetActive(false);
                event3Collider.SetActive(true);
                event4Collider.SetActive(false);
                event5Collider.SetActive(false);
                event7Collider.SetActive(false);
                event8Collider.SetActive(false);
                event9Collider.SetActive(false);

                break;

            case EventsToTrigger.Event4:

                //Debug.Log("Event 4 is triggered");

                clockscript.frezzeTime = true;

                event1Collider.SetActive(false);
                event2Collider.SetActive(false);
                event3Collider.SetActive(false);
                event4Collider.SetActive(true);
                event5Collider.SetActive(false);
                event7Collider.SetActive(false);
                event8Collider.SetActive(false);
                event9Collider.SetActive(false);

                break;

            case EventsToTrigger.Event5:

                //Debug.Log("Event 5 is triggered");

                clockscript.frezzeTime = true;

                event1Collider.SetActive(false);
                event2Collider.SetActive(false);
                event3Collider.SetActive(false);
                event4Collider.SetActive(false);
                event5Collider.SetActive(true);
                event7Collider.SetActive(false);
                event8Collider.SetActive(false);
                event9Collider.SetActive(false);

                break;

            case EventsToTrigger.Event6:

                //Debug.Log("Event 6 is triggered");

                clockscript.frezzeTime = true;

                event1Collider.SetActive(false);
                event2Collider.SetActive(false);
                event3Collider.SetActive(false);
                event4Collider.SetActive(false);
                event5Collider.SetActive(false);
                event7Collider.SetActive(false);
                event8Collider.SetActive(false);
                event9Collider.SetActive(false);

                break;

            case EventsToTrigger.Event7:

                //Debug.Log("Event 7 is triggered");

                clockscript.frezzeTime = true;

                event1Collider.SetActive(false);
                event2Collider.SetActive(false);
                event3Collider.SetActive(false);
                event4Collider.SetActive(false);
                event5Collider.SetActive(false);
                event7Collider.SetActive(true);
                event8Collider.SetActive(false);
                event9Collider.SetActive(false);

                break;

            case EventsToTrigger.Event8:

                //Debug.Log("Event 8 is triggered");

                clockscript.frezzeTime = true;

                event1Collider.SetActive(false);
                event2Collider.SetActive(false);
                event3Collider.SetActive(false);
                event4Collider.SetActive(false);
                event5Collider.SetActive(false);
                event7Collider.SetActive(false);
                event8Collider.SetActive(true);
                event9Collider.SetActive(false);

                break;

            case EventsToTrigger.Event9:

                //Debug.Log("Event 9 is triggered");

                clockscript.frezzeTime = true;

                event1Collider.SetActive(false);
                event2Collider.SetActive(false);
                event3Collider.SetActive(false);
                event4Collider.SetActive(false);
                event5Collider.SetActive(false);
                event7Collider.SetActive(false);
                event8Collider.SetActive(false);
                event9Collider.SetActive(true);

                break;

            case EventsToTrigger.Event10:

                //Debug.Log("Event 10 is triggered");

                clockscript.frezzeTime = true;

                event1Collider.SetActive(false);
                event2Collider.SetActive(false);
                event3Collider.SetActive(false);
                event4Collider.SetActive(false);
                event5Collider.SetActive(false);
                event7Collider.SetActive(false);
                event8Collider.SetActive(false);
                event9Collider.SetActive(false);

                break;
        }
    }

}
