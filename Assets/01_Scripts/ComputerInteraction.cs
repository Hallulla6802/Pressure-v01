using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerInteraction : MonoBehaviour
{
    public Transform player;     // La referencia al jugador
    public float interactionDistance = 2.0f;  // Distancia mínima para interactuar
    public PlayerMovement playerMovement;
    public Camera playerCam;
    public Camera pcFocusCam;
    private bool isInInteraction = false;  // Bandera para saber si el jugador está interactuando
    public GraphicRaycaster canvasRaycaster;
    void Update()
    {
        // Verificar la distancia entre el jugador y la computadora
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance < interactionDistance && !isInInteraction)
        {
            Debug.Log("Esta en Distancia");
            // Si el jugador está lo suficientemente cerca y no está interactuando
            if (Input.GetKeyDown(KeyCode.E))  // Usamos la tecla E para interactuar
            {
                EnterInteraction();
                Debug.Log("Entra a Interaccion");
            }
        }
        else if (isInInteraction && Input.GetKeyDown(KeyCode.E))
        {
            // Permitir salir de la interacción con Escape
            ExitInteraction();
            Debug.Log("Sale a Interaccion");
        }
    }

    void EnterInteraction()
    {
        isInInteraction = true;
        playerMovement.canMove = false;  // Aquí puedes desactivar los controles del jugador, si fuera necesario
        Cursor.lockState = CursorLockMode.None;  // Liberar el mouse para la UI
        Cursor.visible = true;
        playerCam.enabled = false;
        pcFocusCam.enabled = true;
        canvasRaycaster.enabled = true;
    }

    void ExitInteraction()
    {
        isInInteraction = false;
        playerMovement.canMove = true;// Reactivar los controles del jugador     
        Cursor.lockState = CursorLockMode.Locked;  // Bloquear el mouse de nuevo
        Cursor.visible = false;
        playerCam.enabled = true;
        pcFocusCam.enabled = false;
        canvasRaycaster.enabled = true;
    }
}
