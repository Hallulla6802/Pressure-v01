using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static EventManager;

public class RaycastPlayerParaInteractuarConLosObjetos : MonoBehaviour
{
    public float interactionRange = 3f;  // Distancia m�xima para interactuar con la manilla
    private Outline lastOutline = null;
    public KeyCode interactionKey = KeyCode.E;  // La tecla que usaremos para interactuar
    public EventManager eventmanager;
    //Scripts de los colliders
    private Event_1_CollaiderMicrondas event1collaidermicrondas;
    private TextoInteractuarScript textoInteractuarScript;
    private DoorScript doorController;
    [SerializeField] private bool isLookingAtHandle = false;
    private Outline outline;
    public Image CrossHair;
    public Sprite crosshairclossed, crosshairopen;
    public Camera playerCamera;  // La c�mara del jugador
    void Start()
    {
        eventmanager = FindObjectOfType<EventManager>();
        textoInteractuarScript = FindObjectOfType<TextoInteractuarScript>();
        outline = gameObject.GetComponent<Outline>();
    }
    private void Update()
    {

        DetectarObjeto();
    }
    private void DetectarObjeto()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionRange))
        {
            
            // Filtrar por los tags v�lidos
            if (hit.collider.CompareTag("Door"))
            {
                ManejarInteraccionPuerta(hit);
                ActualizarOutline(hit.collider.GetComponent<Outline>()); // Activar Outline para Door
            }
            else if (hit.collider.CompareTag("Microndas") && eventmanager.currentEvent == EventsToTrigger.Event1)
            {
                ManejarInteraccionMicrondas(hit);
                ActualizarOutline(hit.collider.GetComponent<Outline>()); // Activar Outline para Microndas
            }
            else
            {
                CerrarInteraccion();
                ActualizarOutline(null); // No activar Outline
            }
        }
        else
        {
            CerrarInteraccion();
            ActualizarOutline(null); // No hay objeto detectado
        }
    }

    private void ActualizarOutline(Outline newOutline)
    {
        // Desactivar el �ltimo Outline si es diferente del actual
        if (lastOutline != null && lastOutline != newOutline)
        {
            lastOutline.enabled = false;
        }

        // Actualizar el nuevo Outline solo si no es nulo
        lastOutline = newOutline;
        if (lastOutline != null)
        {
            lastOutline.enabled = true;
        }
    }

    private void ManejarInteraccionPuerta(RaycastHit hit)
    {
        if (!isLookingAtHandle)
        {
            DoorScript target = hit.collider.GetComponentInParent<DoorScript>();
            if(target != null)
            {
                textoInteractuarScript.AbrirTextoInteractuar(target.proptText);
            }     
            CrossHair.sprite = crosshairopen;
            isLookingAtHandle = true;
        }

        if (Input.GetKeyDown(interactionKey))
        {
            doorController = hit.collider.GetComponentInParent<DoorScript>();
            if (doorController != null)
            {
                doorController.InteractWithHandle();
            }
        }
    }

    private void ManejarInteraccionMicrondas(RaycastHit hit)
    {
        textoInteractuarScript.AbrirTextoInteractuar("Apagar Microondas");
        CrossHair.sprite = crosshairopen;

        if (Input.GetKeyDown(interactionKey))
        {
            event1collaidermicrondas = hit.collider.GetComponentInParent<Event_1_CollaiderMicrondas>();
            if (event1collaidermicrondas != null)
            {
                event1collaidermicrondas.PrenderMicrondas();
            }
        }
    }

    private void CerrarInteraccion()
    {
        textoInteractuarScript.CerrarTextoInteractuar();
        CrossHair.sprite = crosshairclossed;

        if (isLookingAtHandle)
        {
            isLookingAtHandle = false;
        }
    }
}
