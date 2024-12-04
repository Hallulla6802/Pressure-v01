using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrincipalDoorInteraction : MonoBehaviour
{
    public float interactionRange = 3f;  // Distancia m�xima para interactuar con la manilla
    public string handleTag = "DoorPrincipal";  // El tag que debe tener la manilla
    public KeyCode interactionKey = KeyCode.E;  // La tecla que usaremos para interactuar
    private PrincipalDoorScript principalDoorController;
    private TextoInteractuarScript textoInteractuarScript;
    [SerializeField] private bool isLookingAtHandle = false;
    private Outline outline;
    public Image CrossHair;
    public Sprite crosshairclossed, crosshairopen;
    public Camera playerCamera;  // La c�mara del jugador
    void Start()
    {
        textoInteractuarScript = FindObjectOfType<TextoInteractuarScript>();
        outline = gameObject.GetComponent<Outline>();
    }
    private void Update()
    {
        // Detectamos si el jugador est� mirando hacia la manilla
        DetectHandle();
    }

    // Detecta la manilla usando un raycast
    private void DetectHandle()
    {
        // Lanzamos un raycast desde la c�mara del jugador hacia donde est� mirando
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;
        // Si el raycast impacta con algo dentro del rango de interacci�n
        if (Physics.Raycast(ray, out hit, interactionRange))
        {
            PrincipalDoorScript target = hit.collider.GetComponentInParent<PrincipalDoorScript>();
            // Si el objeto golpeado tiene el tag de la manilla
            if (hit.collider.CompareTag(handleTag))
            {
                if (!isLookingAtHandle)
                {
                    if(target != null)
                    {
                        textoInteractuarScript.AbrirTextoInteractuar(target.proptText);
                    }                                    
                    hit.collider.GetComponent<Outline>().enabled = true;
                    isLookingAtHandle = true;
                    CrossHair.sprite = crosshairopen;
                }

                // Si presionamos la tecla de interacci�n
                if (Input.GetKeyDown(interactionKey))
                {
                    // Intentamos obtener el componente DoorController del objeto golpeado o de su padre
                    principalDoorController = hit.collider.GetComponentInParent<PrincipalDoorScript>();

                    if (principalDoorController != null)
                    {
                        // Llamamos a la funci�n de interacci�n con la manilla
                        principalDoorController.InteractWithHandle();
                    }
                }
            }
            else
            {
                if (isLookingAtHandle)
                {
                    textoInteractuarScript.CerrarTextoInteractuar();
                    outline.enabled = false;
                    isLookingAtHandle = false;
                    CrossHair.sprite = crosshairclossed;
                }
            }
        }
        else
        {
            textoInteractuarScript.CerrarTextoInteractuar();
            outline.enabled = false;
            isLookingAtHandle = false;
            CrossHair.sprite = crosshairclossed;
        }
    }
}
