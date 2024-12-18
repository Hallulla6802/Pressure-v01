using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using static EventManager;

public class PrincipalDoorScript : MonoBehaviour
{
    
    public string openAnimationName = "DoorOpen";  // Nombre de la animaci�n de apertura
    public string closeAnimationName = "DoorClose"; // Nombre de la animaci�n de cierre
    public float closeDelay = 2f;  // Tiempo de retraso para que la puerta se cierre autom�ticamente

    private bool isDoorOpen = false;  // Estado de la puerta (abierta o cerrada)
    [Space]
    public AudioSource closeDoorSound;
    public Animator doorAnimator;  // El componente Animator de la puerta
    public Event_2_CollaiderDoor event2collaiderscript;
    public Event_9_Door event9door;
    public EventManager eventmanager;

    [Header("LOCALIZATION SETTINGS")]
    [Space]
    public string localizationKeyEvent9;
    private LocalizedString currentLocalizationEvent9;

    [Space]
    public string localizationKeyPrincipalDoorName;
    private LocalizedString currentLocalizationPrincipalDoor;
    


    private void Awake()
    {
        event2collaiderscript = FindObjectOfType<Event_2_CollaiderDoor>();
        eventmanager = FindObjectOfType<EventManager>();
        event9door = FindObjectOfType<Event_9_Door>();
    }

    private void Start()
    {
        if (doorAnimator == null)
        {
            doorAnimator = GetComponent<Animator>();
        }

        currentLocalizationEvent9 = new LocalizedString
        {
            TableReference = "Table1",
            TableEntryReference = localizationKeyEvent9
        };

        currentLocalizationPrincipalDoor = new LocalizedString
        {
            TableReference = "Table1",
            TableEntryReference = localizationKeyPrincipalDoorName
        };
        
    }

    public void RefreshLocalizedTextEvent9()
    {
        currentLocalizationEvent9 = new LocalizedString
        {
            TableReference = "Table1",
            TableEntryReference = localizationKeyEvent9
        };

    }

    public void RefreshLocalizedTextPrincipalDoor()
    {
        currentLocalizationPrincipalDoor = new LocalizedString
        {
            TableReference = "Table1",
            TableEntryReference = localizationKeyPrincipalDoorName
        };
    }

    // Funci�n para interactuar con la manilla de la puerta
    public void InteractWithHandle()
    {
        if (!isDoorOpen)
        {
            OpenDoor();
        }
    }

    // Funci�n para abrir la puerta
    private void OpenDoor()
    {
        doorAnimator.Play(openAnimationName);  // Reproduce la animaci�n de apertura
        isDoorOpen = true;

        if(eventmanager.currentEvent != EventsToTrigger.Event2) // Condicion al Evento 2 para que no programe un cierre de puerta si esta el vagabundo.
        {
            Invoke("CloseDoor", closeDelay);  // Programar el cierre de la puerta despu�s del retraso
        }

        if (eventmanager.currentEvent == EventsToTrigger.Event2)
        {
            event2collaiderscript.InteractuarConLaPuertaParaNPC();
        }
    }

    // Funci�n para cerrar la puerta
    public void CloseDoor()
    {
        if (isDoorOpen)
        {
            closeDoorSound.Play();
            doorAnimator.Play(closeAnimationName);  // Reproduce la animaci�n de cierre
            isDoorOpen = false;
        }

       
    }

    public void CloseDoorEvent9()
    {
        if (eventmanager.currentEvent == EventsToTrigger.Event9)
        {
            if (isDoorOpen)
            {
                closeDoorSound.Play();
                doorAnimator.Play(closeAnimationName);  // Reproduce la animaci�n de cierre
                isDoorOpen = false;
                event9door.CerrarPuertaEvent9();
            }
            
        }
    }

    public void OpenDoorEvent9()
    {
        if (!isDoorOpen)
        {
            doorAnimator.Play(openAnimationName);  // Reproduce la animaci�n de apertura
            isDoorOpen = true;
        }
       
     
    }
}
