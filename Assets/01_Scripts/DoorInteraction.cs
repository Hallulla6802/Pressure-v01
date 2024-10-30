using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public float interactionRange = 3f;  // Distancia máxima para interactuar con la manilla
    public string handleTag = "Handle";  // El tag que debe tener la manilla
    public KeyCode interactionKey = KeyCode.E;  // La tecla que usaremos para interactuar
    private DoorScript doorController;
    private TextoInteractuarScript textoInteractuarScript;
    private bool isLookingAtHandle = false;
    private Outline outline;
   
    public Camera playerCamera;  // La cámara del jugador
    void Start()
    {
        textoInteractuarScript = FindObjectOfType<TextoInteractuarScript>(); 
        outline = gameObject.GetComponent<Outline>();
    }
    private void Update()
    {
        // Detectamos si el jugador está mirando hacia la manilla
        DetectHandle();
    }

    // Detecta la manilla usando un raycast
    private void DetectHandle()
    {
        // Lanzamos un raycast desde la cámara del jugador hacia donde esté mirando
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        // Si el raycast impacta con algo dentro del rango de interacción
        if (Physics.Raycast(ray, out hit, interactionRange))
        {
            // Si el objeto golpeado tiene el tag de la manilla
            if (hit.collider.CompareTag(handleTag))
            {
                if(!isLookingAtHandle)
                {
                    textoInteractuarScript.AbrirTextoInteractuar();
                    outline.enabled = true;
                    isLookingAtHandle = true;
                }
               
                // Si presionamos la tecla de interacción
                if (Input.GetKeyDown(interactionKey))
                {
                    // Intentamos obtener el componente DoorController del objeto golpeado o de su padre
                    doorController = hit.collider.GetComponentInParent<DoorScript>();

                    if (doorController != null)
                    {
                        // Llamamos a la función de interacción con la manilla
                        doorController.InteractWithHandle();                   
                    }
                }
            }
            else
            {
               if(isLookingAtHandle)
               {
                    textoInteractuarScript.CerrarTextoInteractuar();
                    outline.enabled = false;
                    isLookingAtHandle = false;
               } 
            }
        }
    }
}
