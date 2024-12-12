using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    //Los scripts que vamos a utlizar.
    public ClockScript clockscript;
    public MecanographicScript mecanographicscript;
    public ComputerInteraction computerInteraction;
    public ObjectivesManager objMan;
   

    public Evento_10 evento_10;
    public GameObject pcScreen;

    public int eventCount;
    public GameObject audioVentilador;

    public Button UploadProjectButton;
    public GameObject buttonUpload;



    private EventsToTrigger lastEvent;

    //Dos variables del tiempo del evento correspondiente, basicamente actuan como un rango para definir cuando ocurre el evento. Y tambien un bool para definir si se "Triggereo" el evento o no.
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
        Event10, //Evento de spawn de sombras en el "livin"
        Final12,
        SentProyect
    }

    [Space]
    public EventsToTrigger currentEvent;
    [Space]
    [Header("EMPTY COLLIDERS FOR EVENTS")]
    [Space]

    //Los Collider de cada evento, los cuales al presionarlos se activan.
    public GameObject event1Collider;
    public GameObject event2Collider;
    public GameObject event3Collider;
    public GameObject event4Collider;
    public GameObject event5Collider;
    public GameObject event6Collider;
    public GameObject event7Collider;
    public GameObject event8Collider;
    public GameObject event9Collider;
    public GameObject finalCollider;






    private void Awake()
    {
        SetearLosScriptsQueVamosAUtilizarEnEsteCodigo();
    }



    private void Start()
    {
        TodosLosCollidersSeDesactivanYElCurreventEventNadaEstaPasandoAlIniciarElJuego();
    }
    private void Update() //Se verifica constantemente si las tareas estan ya hechas para aumentar el tiempo, y si las condiciones de los eventos ya estan para activarse, segun lo amerite.
    {
        ElTiempoPasaMasRapidoSiLasTareasYaEstanHechas();

        SeVerificaElTiempoParaActivarElTriggerYElEvento1();

        SeVerificaElTiempoParaActivarElTriggerYElEvento2();

        SeVerificaElTiempoParaActivarElTriggerYElEvento3();

        SeVerificaElTiempoParaActivarElTriggerYElEvento4();

        SeVerificaElTiempoParaActivarElTriggerYElEvento5();

        SeVerificaElTiempoParaActivarElTriggerYElEvento6();

        SeVerificaElTiempoParaActivarElTriggerYElEvento7();

        SeVerificaElTiempoParaActivarElTriggerYElEvento8();

        SeVerificaElTiempoParaActivarElTriggerYElEvento9();


        CambiarEventos();

    }

    void AumentoMinMaxCurrentyArregloTimeScale() //Este es el aumento, para que cuando termine un evento y vuelvas al escritorio, se aumente el maximo y minimos de tarreas de mecanografia.
    {
        eventCount += 1;
        clockscript.timeScale = 1f;
        mecanographicscript.minimumMecanoAmount += 4;
        mecanographicscript.maximumMecanoAmout += 4;
    }

    void CambiarEventos()
    {
        if (currentEvent != lastEvent)  //Se verifica si ya paso el evento anterior.
        {
            switch (currentEvent)  //Con el switch pasamos del "None" al "Event" correspondido que queremos que pase.
            {
                case EventsToTrigger.None:

                    EventNothingIsHappening();

                    break;

                case EventsToTrigger.Event1:

                    Event1();

                    break;

                case EventsToTrigger.Event2:

                    Event2();

                    break;

                case EventsToTrigger.Event3:

                    Event3();

                    break;

                case EventsToTrigger.Event4:

                    Event4();

                    break;

                case EventsToTrigger.Event5:

                    Event5();

                    break;

                case EventsToTrigger.Event6:

                    Event6();

                    break;

                case EventsToTrigger.Event7:

                    Event7();

                    break;


                case EventsToTrigger.Event8:

                    Event8();

                    break;

                case EventsToTrigger.Event9:

                    Event9();

                    break;

                case EventsToTrigger.Final12:

                    EventFinal12();

                    break;

               


            }

            lastEvent = currentEvent;
        }
    }
    void EventNothingIsHappening() //La mayoria de los void Events siguen la misma logica.
    {
        //El tiempo congelado se desactiva, se activa la pantalla del pc, y de desactiva todos los collaiders que gatillen el evento, salvo el evento correspondido.
        clockscript.frezzeTime = false;
        pcScreen.SetActive(true);
        event1Collider.SetActive(false);
        event2Collider.SetActive(false);
        event3Collider.SetActive(false);
        event4Collider.SetActive(false);
        event5Collider.SetActive(false);
        event6Collider.SetActive(false);
        event7Collider.SetActive(false);
        event8Collider.SetActive(false);
        event9Collider.SetActive(false);

        audioVentilador.SetActive(true);
        finalCollider.SetActive(false);
    }

    void Event1()
    {
        //Debug.Log("Event 1 is triggered");
        evento_10.ShadowEvent1(); //Evento el cual spawnea la sombra en el "livin" esta esta enumerada para que sea una sombra en especifico. 
        computerInteraction.ExitInteraction();
        clockscript.frezzeTime = true;
        AumentoMinMaxCurrentyArregloTimeScale();
        event1Collider.SetActive(true);
        event2Collider.SetActive(false);
        event3Collider.SetActive(false);
        event4Collider.SetActive(false);
        event5Collider.SetActive(false);
        event6Collider.SetActive(false);
        event7Collider.SetActive(false);
        event8Collider.SetActive(false);
        event9Collider.SetActive(false);

        finalCollider.SetActive(false);
    }

    void Event2()
    {
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
        event7Collider.SetActive(false);
        event8Collider.SetActive(false);

        finalCollider.SetActive(false);
    }

    void Event3()
    {
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
        event7Collider.SetActive(false);
        event8Collider.SetActive(false);
        event9Collider.SetActive(false);

        audioVentilador.SetActive(false);
        finalCollider.SetActive(false);
    }

    void Event4()
    {
        //Debug.Log("Event 4 is triggered");
        computerInteraction.ExitInteraction();
        clockscript.frezzeTime = true;
        AumentoMinMaxCurrentyArregloTimeScale();
        event1Collider.SetActive(false);
        event2Collider.SetActive(false);
        event3Collider.SetActive(false);
        event4Collider.SetActive(true);
        event5Collider.SetActive(false);
        event7Collider.SetActive(false);
        event8Collider.SetActive(false);
        event9Collider.SetActive(false);

        finalCollider.SetActive(false);
    }

    void Event5()
    {
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
        event7Collider.SetActive(false);
        event8Collider.SetActive(false);
        event9Collider.SetActive(false);

        finalCollider.SetActive(false);
    }

    void Event6()
    {
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
        event7Collider.SetActive(false);
        event8Collider.SetActive(false);
        event9Collider.SetActive(false);

        finalCollider.SetActive(false);
    }

    void Event7()
    {
        //Debug.Log("Event 6 is triggered");
        
        clockscript.frezzeTime = true;
        AumentoMinMaxCurrentyArregloTimeScale();
        computerInteraction.ExitInteraction();
        event1Collider.SetActive(false);
        event2Collider.SetActive(false);
        event3Collider.SetActive(false);
        event4Collider.SetActive(false);
        event5Collider.SetActive(false);
        event6Collider.SetActive(false);
        event7Collider.SetActive(true);
        event8Collider.SetActive(false);
        event9Collider.SetActive(false);

        finalCollider.SetActive(false);
    }

    void Event8()
    {
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
        event7Collider.SetActive(false);
        event8Collider.SetActive(true);
        event9Collider.SetActive(false);

        finalCollider.SetActive(false);
    }

    void Event9()
    {
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
        event7Collider.SetActive(false);
        event8Collider.SetActive(false);
        event9Collider.SetActive(true);

        finalCollider.SetActive(false);
    }

    void EventFinal12()
    {
        event1Collider.SetActive(false);
        event2Collider.SetActive(false);
        event3Collider.SetActive(false);
        event4Collider.SetActive(false);
        event5Collider.SetActive(false);
        event6Collider.SetActive(false);
        event7Collider.SetActive(false);
        event8Collider.SetActive(false);
        event9Collider.SetActive(false);

        finalCollider.SetActive(true);
        UploadProjectButton.interactable = true;
        buttonUpload.SetActive(true);
    }

   

    void ElTiempoPasaMasRapidoSiLasTareasYaEstanHechas()
    {
        if (mecanographicscript.currentAmount >= mecanographicscript.maximumMecanoAmout) //Si el numero de tareas hecho es igual al maximo, se aumenta la escala del tiempo.
        {
            clockscript.timeScale = 10f;
        }
    }

    void SeVerificaElTiempoParaActivarElTriggerYElEvento1() //Todos los demas void siguen la misma logica.
    {
        //Si el trigger del evento correspondiente no esta activado y el tiempo en minutos es mayor que el tiempo del evento, pero menor que el limite, ocurre lo siguiente:
        if (!event1Trigged && clockscript.timeInMinutes >= timeEvent1 && clockscript.timeInMinutes <= timeEvent1Limit) //Por lo que si, para verificar el evento hay que crear una variable de EventTrigged, TimeEvent y timeEventLimit para cada evento
        {  //La razon por la cual hay como un rango de tiempo por asi decirlo, es que los minutos son un float, es decir dicimales. Y muchas veces pasaba que el tiempo pasaba muy rapido y no alcanzaba el valor exacto, a como lo seria un int.
            //Si las tareas de mecanografia son menores que el minimo establecido, se congela el tiempo para que el jugador pueda terminarlas.
            if (mecanographicscript.currentAmount < mecanographicscript.minimumMecanoAmount)
            {

                clockscript.frezzeTime = true;

            }
            //Si las tareas de mecanografia son mayores o igual que el minimo establecido, se cambie el current event, al evento corresponido para acitvarlo, se prende el trigged y se actualiza el objetivo de las tareas.
            if (mecanographicscript.currentAmount >= mecanographicscript.minimumMecanoAmount)
            {
                currentEvent = EventsToTrigger.Event1;
                objMan.currentStates = ObjectivesManager.ObjectiveStates.InvestigateMicrowave;
                event1Trigged = true;


            }

        }
    }
    void SeVerificaElTiempoParaActivarElTriggerYElEvento2()
    {
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
    }

    void SeVerificaElTiempoParaActivarElTriggerYElEvento3()
    {
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
    }

    void SeVerificaElTiempoParaActivarElTriggerYElEvento4()
    {
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
    }

    void SeVerificaElTiempoParaActivarElTriggerYElEvento5()
    {
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
    }

    void SeVerificaElTiempoParaActivarElTriggerYElEvento6()
    {
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
    }

    void SeVerificaElTiempoParaActivarElTriggerYElEvento7()
    {
        if (!eventTrigged7 && clockscript.timeInMinutes >= timeEvent7 && clockscript.timeInMinutes <= timeEvent7Limit)
        {
            if (mecanographicscript.currentAmount < mecanographicscript.minimumMecanoAmount)
            {

                clockscript.frezzeTime = true;

            }
            if (mecanographicscript.currentAmount >= mecanographicscript.minimumMecanoAmount)
            {
                //Debug.Log("Se gatilla el evento6 Radio Fix");
                currentEvent = EventsToTrigger.Event7;
                objMan.currentStates = ObjectivesManager.ObjectiveStates.InvestigateFight;
                eventTrigged7 = true;
            }

        }
    }

    void SeVerificaElTiempoParaActivarElTriggerYElEvento8()
    {
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
                objMan.currentStates = ObjectivesManager.ObjectiveStates.InvestigateSteps;
                eventTrigged8 = true;
            }

        }
    }

    void SeVerificaElTiempoParaActivarElTriggerYElEvento9()
    {
        if (!eventTrigged9 && clockscript.timeInMinutes >= timeEvent9 && clockscript.timeInMinutes <= timeEvent9Limit)
        {
            if (mecanographicscript.currentAmount < mecanographicscript.minimumMecanoAmount)
            {

                clockscript.frezzeTime = true;

            }
            if (mecanographicscript.currentAmount >= mecanographicscript.minimumMecanoAmount)
            {
                //Debug.Log("Se abre la puerta");
                currentEvent = EventsToTrigger.Event9;
                objMan.currentStates = ObjectivesManager.ObjectiveStates.CloseTheDoor;
                eventTrigged9 = true;
            }

        }
    }

    void TodosLosCollidersSeDesactivanYElCurreventEventNadaEstaPasandoAlIniciarElJuego()
    {
        objMan = FindObjectOfType<ObjectivesManager>();
        UploadProjectButton.interactable = false;
        buttonUpload.SetActive(false);
        lastEvent = EventsToTrigger.None;

        event1Collider.SetActive(false);
        event2Collider.SetActive(false);
        event3Collider.SetActive(false);
        event4Collider.SetActive(false);
        event5Collider.SetActive(false);
        event6Collider.SetActive(false);
        event7Collider.SetActive(false);
        event8Collider.SetActive(false);
        event9Collider.SetActive(false);
        finalCollider.SetActive(false);
    }

    void SetearLosScriptsQueVamosAUtilizarEnEsteCodigo()
    {
        clockscript = FindObjectOfType<ClockScript>();
        mecanographicscript = FindObjectOfType<MecanographicScript>();
        computerInteraction = FindObjectOfType<ComputerInteraction>();
        evento_10 = FindObjectOfType<Evento_10>();
        
    }
}
