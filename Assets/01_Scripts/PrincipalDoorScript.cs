using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class PrincipalDoorScript : MonoBehaviour
{
    public Animator doorAnimator;  // El componente Animator de la puerta
    public string openAnimationName = "DoorOpen";  // Nombre de la animaci�n de apertura
    public string closeAnimationName = "DoorClose"; // Nombre de la animaci�n de cierre
    public float closeDelay = 2f;  // Tiempo de retraso para que la puerta se cierre autom�ticamente
    private bool isDoorOpen = false;  // Estado de la puerta (abierta o cerrada)
    public Event_2_CollaiderDoor event2collaiderscript;
    public EventManager eventmanager;
    public string proptText;

    private void Awake()
    {
        event2collaiderscript = FindObjectOfType<Event_2_CollaiderDoor>();
        eventmanager = FindObjectOfType<EventManager>();
    }

    private void Start()
    {
        if (doorAnimator == null)
        {
            doorAnimator = GetComponent<Animator>();
        }
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
        Invoke("CloseDoor", closeDelay);  // Programar el cierre de la puerta despu�s del retraso
        if (eventmanager.currentEvent == EventsToTrigger.Event2)
        {
            event2collaiderscript.InteractuarConLaPuertaParaResolverElEvento2();
        }
    }

    // Funci�n para cerrar la puerta
    private void CloseDoor()
    {
        if (isDoorOpen)
        {
            doorAnimator.Play(closeAnimationName);  // Reproduce la animaci�n de cierre
            isDoorOpen = false;
        }
    }
}
