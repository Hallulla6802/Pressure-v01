using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EventManager : MonoBehaviour
{
    public ClockScript clockscript;
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
    //public Gameobject event4Collider;
    //public Gameobject event5Collider;
    //public Gameobject event6Collider;
    public GameObject event7Collider;
    public GameObject event8Collider;
    //public Gameobject event9Collider;
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
        event7Collider.SetActive(false);
        event8Collider.SetActive(false);
    }

    private void Update()
    {
        switch (currentEvent) 
        {
            case EventsToTrigger.None:

               // Debug.Log("Nothing is happening");

                clockscript.frezzeTime = false;

                event1Collider.SetActive(false);
                event2Collider.SetActive(false);
                event3Collider.SetActive(false);
                event7Collider.SetActive(false);
                event8Collider.SetActive(false);

                break;

            case EventsToTrigger.Event1:

                //Debug.Log("Event 1 is triggered");

                clockscript.frezzeTime = true;

                event1Collider.SetActive(true);
                event2Collider.SetActive(false);
                event3Collider.SetActive(false);
                event7Collider.SetActive(false);
                event8Collider.SetActive(false);


                break; 
            
            case EventsToTrigger.Event2:

                //Debug.Log("Event 2 is triggered");

                clockscript.frezzeTime = true;

                event1Collider.SetActive(false);
                event2Collider.SetActive(true);
                event3Collider.SetActive(false);
                event7Collider.SetActive(false);
                event8Collider.SetActive(false);

                break;

            case EventsToTrigger.Event3:

                //Debug.Log("Event 3 is triggered");

                clockscript.frezzeTime = true;

                event1Collider.SetActive(false);
                event2Collider.SetActive(false);
                event3Collider.SetActive(true);
                event7Collider.SetActive(false);
                event8Collider.SetActive(false);

                break;

            case EventsToTrigger.Event4:

                //Debug.Log("Event 4 is triggered");

                clockscript.frezzeTime = true;

                event1Collider.SetActive(false);
                event2Collider.SetActive(false);
                event3Collider.SetActive(false);
                event7Collider.SetActive(false);
                event8Collider.SetActive(false);

                break;

            case EventsToTrigger.Event5:

                //Debug.Log("Event 5 is triggered");

                clockscript.frezzeTime = true;

                event1Collider.SetActive(false);
                event2Collider.SetActive(false);
                event3Collider.SetActive(false);
                event7Collider.SetActive(false);
                event8Collider.SetActive(false);

                break;

            case EventsToTrigger.Event6:

                //Debug.Log("Event 6 is triggered");

                clockscript.frezzeTime = true;

                event1Collider.SetActive(false);
                event2Collider.SetActive(false);
                event3Collider.SetActive(false);
                event7Collider.SetActive(false);
                event8Collider.SetActive(false);

                break;

            case EventsToTrigger.Event7:

                //Debug.Log("Event 7 is triggered");

                clockscript.frezzeTime = true;

                event1Collider.SetActive(false);
                event2Collider.SetActive(false);
                event3Collider.SetActive(false);
                event7Collider.SetActive(true);
                event8Collider.SetActive(false);

                break;

            case EventsToTrigger.Event8:

                //Debug.Log("Event 8 is triggered");

                clockscript.frezzeTime = true;

                event1Collider.SetActive(false);
                event2Collider.SetActive(false);
                event3Collider.SetActive(false);
                event7Collider.SetActive(false);
                event8Collider.SetActive(true);

                break;

            case EventsToTrigger.Event9:

                //Debug.Log("Event 9 is triggered");

                clockscript.frezzeTime = true;

                event1Collider.SetActive(false);
                event2Collider.SetActive(false);
                event3Collider.SetActive(false);
                event7Collider.SetActive(false);
                event8Collider.SetActive(false);

                break;

            case EventsToTrigger.Event10:

                //Debug.Log("Event 10 is triggered");

                clockscript.frezzeTime = true;

                event1Collider.SetActive(false);
                event2Collider.SetActive(false);
                event3Collider.SetActive(false);
                event7Collider.SetActive(false);
                event8Collider.SetActive(false);

                break;
        }
    }

}
