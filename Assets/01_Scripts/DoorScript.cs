using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Animator doorAnimator;  // El componente Animator de la puerta
    public string openAnimationName = "DoorOpen";  // Nombre de la animación de apertura
    public string closeAnimationName = "DoorClose"; // Nombre de la animación de cierre
    public float closeDelay = 2f;  // Tiempo de retraso para que la puerta se cierre automáticamente
    public bool isDoorOpen = false;  // Estado de la puerta (abierta o cerrada)
    public string proptText;

    private void Start()
    {
        if (doorAnimator == null)
        {
            doorAnimator = GetComponent<Animator>();
        }
    }

    // Función para interactuar con la manilla de la puerta
    public void InteractWithHandle()
    {
        if (!isDoorOpen)
        {
            OpenDoor();
        }
    }

    // Función para abrir la puerta
    private void OpenDoor()
    {
        doorAnimator.Play(openAnimationName);  // Reproduce la animación de apertura
        isDoorOpen = true;
        Invoke("CloseDoor", closeDelay);  // Programar el cierre de la puerta después del retraso
        
    }

    // Función para cerrar la puerta
    private void CloseDoor()
    {
        if (isDoorOpen)
        {
            doorAnimator.Play(closeAnimationName);  // Reproduce la animación de cierre
            isDoorOpen = false;
        }
    }
}
