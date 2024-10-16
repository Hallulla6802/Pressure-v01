using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ComputerInteraction : MonoBehaviour
{
    public Transform player;     // La referencia al jugador
    public float interactionDistance = 2.0f;  // Distancia mínima para interactuar
    public PlayerMovement playerMovement;
    public CameraScript cameraScript;
    public Camera playerCam;
    public Camera pcFocusCam;
    private bool isInInteraction = false;  // Bandera para saber si el jugador está interactuando
    public TMP_InputField inputField;
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
    }

    void EnterInteraction()
    {
        isInInteraction = true;
        playerMovement.canMove = false;  // Aquí puedes desactivar los controles del jugador, si fuera necesario
        cameraScript.canLook = false;
        Cursor.lockState = CursorLockMode.None;  // Liberar el mouse para la UI
        Cursor.visible = true;
        playerCam.enabled = false;
        pcFocusCam.enabled = true;
    }

    public void ExitInteraction()
    {
        isInInteraction = false;
        playerMovement.canMove = true;// Reactivar los controles del jugador   
        cameraScript.canLook = true;  
        Cursor.lockState = CursorLockMode.Locked;  // Bloquear el mouse de nuevo
        Cursor.visible = false;
        playerCam.enabled = true;
        pcFocusCam.enabled = false;
        DeselectAndClear();
    }
    public void DeselectAndClear()
    {
        EventSystem.current.SetSelectedGameObject(null); // Deselecciona el objeto
        inputField.DeactivateInputField(); // Desactiva el InputField
        inputField.text = string.Empty; // Limpia el texto
    }
}
