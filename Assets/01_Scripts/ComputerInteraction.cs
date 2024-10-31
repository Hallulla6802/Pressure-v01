using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using static EventManager;

public class ComputerInteraction : MonoBehaviour
{
    [SerializeField] TextoInteractuarScript textoInteractuarScript;
    [SerializeField] EventManager eventManager;
    [SerializeField] EventSystem eventSystem;
    public Button Butonllamado;
    public Transform player;     // La referencia al jugador
    public float interactionDistance = 2.0f;  // Distancia mínima para interactuar
    public PlayerMovement playerMovement;
    public CameraScript cameraScript;
    public Camera playerCam;
    public Camera pcFocusCam;
    public bool isInInteraction = false;  // Bandera para saber si el jugador está interactuando
    public TMP_InputField inputField;
    public bool isTriggerMessage;
    public Outline pcOutline;
    public Image crosshair;

    public AudioSource sonidoClick;
    private void Awake()
    {
        GameObject clickObject = GameObject.Find("Click Mouse");

        if (clickObject != null)
        {
           sonidoClick = clickObject.GetComponent<AudioSource>();
        }

        eventManager = FindObjectOfType<EventManager>();
        textoInteractuarScript = FindObjectOfType<TextoInteractuarScript>();
        eventSystem = FindObjectOfType<EventSystem>();
    }
    void Update()
    {


            // Si el jugador está lo suficientemente cerca y no está interactuando y esta en el trigger del computador
            if (Input.GetKeyDown(KeyCode.E) && !isInInteraction && isTriggerMessage)  // Usamos la tecla E para interactuar
            {
                if (eventManager.currentEvent == EventsToTrigger.None || eventManager.currentEvent == EventsToTrigger.Final12)
                {
                   EnterInteraction();
                   textoInteractuarScript.CerrarTextoInteractuar();
                   pcOutline.enabled = false;
                }

            
                else
                {

                }
            }

            if (isInInteraction && Input.GetMouseButtonDown(0))
            {
                sonidoClick.Play();
            }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggerMessage = true;
            textoInteractuarScript.AbrirTextoInteractuar();
            pcOutline.enabled = true;
        }
    }

   

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggerMessage = false;
            isInInteraction = false;
            textoInteractuarScript.CerrarTextoInteractuar();
            pcOutline.enabled = false;
        }
    }
    public void OnDisable()
    {
        ExitInteraction();
    }

    public void EnterInteraction()
    {
        isInInteraction = true;
        playerMovement.canMove = false;  // Aquí puedes desactivar los controles del jugador, si fuera necesario
        cameraScript.canLook = false;
        Cursor.lockState = CursorLockMode.None;  // Liberar el mouse para la UI
        Cursor.visible = true;
        playerCam.enabled = false;
        pcFocusCam.enabled = true;
        crosshair.enabled = false;
    }

    public void ExitInteraction()
    {
        isInInteraction = false;
        isTriggerMessage = false;
        playerMovement.canMove = true;// Reactivar los controles del jugador   
        cameraScript.canLook = true;  
        Cursor.lockState = CursorLockMode.Locked;  // Bloquear el mouse de nuevo
        Cursor.visible = false;        
        playerCam.enabled = true;       
        pcFocusCam.enabled = false;
        crosshair.enabled = true;
        DeselectAndClear();
    }
    public void DeselectAndClear()
    {
        eventSystem.SetSelectedGameObject(null); // Deselecciona el objeto
        inputField.DeactivateInputField(); // Desactiva el InputField
        inputField.text = string.Empty; // Limpia el texto
    }
}
