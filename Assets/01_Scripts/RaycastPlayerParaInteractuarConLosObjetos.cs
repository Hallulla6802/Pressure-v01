using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine;
using UnityEngine.UI;
using static EventManager;

public class RaycastPlayerParaInteractuarConLosObjetos : MonoBehaviour
{
    public float interactionRange = 2f;  // Distancia maxima para intractuar con los objetos
    private Outline lastOutline = null;
    public KeyCode interactionKey = KeyCode.E;  // La tecla que usaremos para interactuar
    public EventManager eventmanager;

    [Space]
    //Scripts de los colliders
    public ComputerInteraction computerInteracion;
    private Event_1_CollaiderMicrondas event1collaidermicrondas;
    private Event_3_Object event3objects;
    private Event_4_Sink event4sink;
    private Event_5_TV event5tv;
    private Event_6_RadioTrigger event6radiotrigger;
    [Space]
    private TextoInteractuarScript textoInteractuarScript;
    private DoorScript doorController;
    private PrincipalDoorScript principalDoorScript;
    [SerializeField] private bool isLookingAtHandle = false;
    [SerializeField] private Outline outlinePC;
    private Outline outline;
    public Image CrossHair;
    public Sprite crosshairclossed, crosshairopen;
    public Camera playerCamera;  // La c�mara del jugador

    [Space]
    [Header("LOCALIZATION KEYS")]
    [Space]
    public string pclocalizedKey;
    private LocalizedString currentpcKey;

    public string microwaveLocalizedKey;
    private LocalizedString currentMicrowaveKey;

    public string generatorLocalizatedKey;
    private LocalizedString currentGeneratorKey;

    public string faucetLocalizedKey;
    private LocalizedString currentFaucetKey;

    public string TvLocalizedKey;
    private LocalizedString currentTvKey;

    public string radioLocalizedKey;
    private LocalizedString currentRadioKey;
    void Start()
    {
        eventmanager = FindObjectOfType<EventManager>();
        textoInteractuarScript = FindObjectOfType<TextoInteractuarScript>();
        outline = gameObject.GetComponent<Outline>();
        computerInteracion = FindObjectOfType<ComputerInteraction>();

        //Loc functions

        RefreshTextPC();
        RefreshTextMicrowave();
        RefreshTextGenerator();
        RefreshTextFaucet();
        RefreshTextTV();
        RefreshTextRadio();
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

            else if (hit.collider.CompareTag("Door2"))
            {
                ManejarInteraccionPuertaPrincipal(hit);
                ActualizarOutline(hit.collider.GetComponent<Outline>());

            }
            else if (hit.collider.CompareTag("PC"))
            {
                InteraccionPC(hit);
                  // Activar Outline para PC
            }
            else if (hit.collider.CompareTag("Microndas") && eventmanager.currentEvent == EventsToTrigger.Event1)
            {
                ManejarInteraccionMicrondas(hit);
                ActualizarOutline(hit.collider.GetComponent<Outline>()); // Activar Outline para Microndas
            }

            else if (hit.collider.CompareTag("Generador") && eventmanager.currentEvent == EventsToTrigger.Event3)
            {
                InteraccionGenerador(hit);
                ActualizarOutline(hit.collider.GetComponent<Outline>()); // Activar Outline para el Generador
            }
            else if (hit.collider.CompareTag("Lavamanos") && eventmanager.currentEvent == EventsToTrigger.Event4)
            {
                InteraccionLavamanos(hit);
                ActualizarOutline(hit.collider.GetComponent<Outline>()); // Activar Outline para el Lavamanos
            }
            else if (hit.collider.CompareTag("TV") && eventmanager.currentEvent == EventsToTrigger.Event5)
            {
                ApagarLaTele(hit);
                ActualizarOutline(hit.collider.GetComponent<Outline>()); // Activar Outline para el TV
            }
            else if (hit.collider.CompareTag("Radio") && eventmanager.currentEvent == EventsToTrigger.Event6)
            {
                ApagarLaRadio(hit);
                ActualizarOutline(hit.collider.GetComponent<Outline>()); // Activar Outline para el Radio
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
            if (target != null)
            {
                string localizedText = target.GetLocalizedPropText();  // Get localized text for the door
                textoInteractuarScript.AbrirTextoInteractuar(localizedText); // Pass the localized text to your UI script
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

    private void ManejarInteraccionPuertaPrincipal(RaycastHit hit)
    {
        if (!isLookingAtHandle)
        {
            PrincipalDoorScript target = hit.collider.GetComponentInParent<PrincipalDoorScript>();
            if (target != null)
            {
                if (eventmanager.currentEvent == EventsToTrigger.Event9)
                {
                    // Lógica de la key de localización para el Evento 9
                    string localizedText = LocalizationSettings.StringDatabase.GetLocalizedString("Table1", target.localizationKeyEvent9);
                    textoInteractuarScript.AbrirTextoInteractuar(localizedText);
                }
                else
                {
                    // Situación ordinaria de "Abrir puerta principal" con localización fija
                    string openText = LocalizationSettings.StringDatabase.GetLocalizedString("Table1", target.localizationKeyPrincipalDoorName);
                    textoInteractuarScript.AbrirTextoInteractuar(openText);
                }
            }
            CrossHair.sprite = crosshairopen;
            isLookingAtHandle = true;
        }

        if (Input.GetKeyDown(interactionKey))
        {
            principalDoorScript = hit.collider.GetComponentInParent<PrincipalDoorScript>();
            if (principalDoorScript != null)
            {
                if (eventmanager.currentEvent == EventsToTrigger.Event9)
                {
                    principalDoorScript.CloseDoorEvent9();
                }
                else
                {
                    principalDoorScript.InteractWithHandle();
                }
            }
        }
    }

    #region LOCALIZATION FUNCTIONS

    public void RefreshTextPC()
    {
        currentpcKey = new LocalizedString
        {
            TableReference = "Table1",
            TableEntryReference = pclocalizedKey
        };
    }

    public void RefreshTextMicrowave()
    {
        currentMicrowaveKey = new LocalizedString
        {
            TableReference = "Table1",
            TableEntryReference = microwaveLocalizedKey
        };
    }

    public void RefreshTextGenerator()
    {
        currentGeneratorKey = new LocalizedString
        {
            TableReference = "Table1",
            TableEntryReference = generatorLocalizatedKey
        };
    }

    public void RefreshTextFaucet()
    {
        currentFaucetKey = new LocalizedString
        {
            TableReference = "Table1",
            TableEntryReference = faucetLocalizedKey
        };
    }

    public void RefreshTextTV()
    {
        currentTvKey = new LocalizedString
        {
            TableReference = "Table1",
            TableEntryReference = TvLocalizedKey
        };
    }

    public void RefreshTextRadio()
    {
        currentRadioKey = new LocalizedString
        {
            TableReference = "Table1",
            TableEntryReference = radioLocalizedKey
        };
    }

    #endregion


    private void InteraccionPC(RaycastHit hit)
    {
        if (!computerInteracion.isInInteraction)
        {
            if (eventmanager.currentEvent == EventsToTrigger.None || eventmanager.currentEvent == EventsToTrigger.Final12)
            {
                ActualizarOutline(outlinePC);

                //Localized change text
                string localizedPCkey = LocalizationSettings.StringDatabase.GetLocalizedString("Table1", pclocalizedKey);
                textoInteractuarScript.AbrirTextoInteractuar(localizedPCkey);

                CrossHair.sprite = crosshairopen;
            }
          
        }
        else
        {
            CerrarInteraccion();
            ActualizarOutline(null);
        }

        if (Input.GetKeyDown(interactionKey))
        {
                computerInteracion.TrabajarEnPC();
        }
    }

    private void ManejarInteraccionMicrondas(RaycastHit hit)
    {
        //Localization change text
        string localizedMicrowaveKey = LocalizationSettings.StringDatabase.GetLocalizedString("Table1", microwaveLocalizedKey);
        textoInteractuarScript.AbrirTextoInteractuar(localizedMicrowaveKey);

        CrossHair.sprite = crosshairopen;

        if (Input.GetKeyDown(interactionKey))
        {
            event1collaidermicrondas = hit.collider.GetComponentInParent<Event_1_CollaiderMicrondas>();
            if (event1collaidermicrondas != null)
            {
                event1collaidermicrondas.ApagarMicroondas();
                
            }
        }
    }

    private void InteraccionGenerador(RaycastHit hit)
    {
        //Localization change text
        string localizedGeneratorKey = LocalizationSettings.StringDatabase.GetLocalizedString("Table1", generatorLocalizatedKey);
        textoInteractuarScript.AbrirTextoInteractuar(localizedGeneratorKey);

        CrossHair.sprite = crosshairopen;

        if (Input.GetKeyDown(interactionKey))
        {
            event3objects = hit.collider.GetComponentInParent<Event_3_Object>();
            if (event3objects != null)
            {
                event3objects.PrenderLuces();
            }
        }
    }
    private void InteraccionLavamanos(RaycastHit hit)
    {
        //Localization change text
        string localizedFaucetKey = LocalizationSettings.StringDatabase.GetLocalizedString("Table1", faucetLocalizedKey);
        textoInteractuarScript.AbrirTextoInteractuar(localizedFaucetKey);

        CrossHair.sprite = crosshairopen;

        if (Input.GetKeyDown(interactionKey))
        {
            event4sink = hit.collider.GetComponentInParent<Event_4_Sink>();
            if (event4sink != null)
            {
                event4sink.CerrarLavamanos();

            }
        }
    }

    private void ApagarLaTele(RaycastHit hit)
    {
        //Localization change text
        string localizedTVKey = LocalizationSettings.StringDatabase.GetLocalizedString("Table1", TvLocalizedKey);
        textoInteractuarScript.AbrirTextoInteractuar(localizedTVKey);

        CrossHair.sprite = crosshairopen;

        if (Input.GetKeyDown(interactionKey))
        {
            event5tv = hit.collider.GetComponentInParent<Event_5_TV>();
            if (event5tv != null)
            {
                event5tv.ApagarTele();

            }
        }
    }

    private void ApagarLaRadio(RaycastHit hit)
    {
        //Localization change text
        string localizedRadioKey = LocalizationSettings.StringDatabase.GetLocalizedString("Table1", radioLocalizedKey);
        textoInteractuarScript.AbrirTextoInteractuar(localizedRadioKey);

        CrossHair.sprite = crosshairopen;

        if (Input.GetKeyDown(interactionKey))
        {
            event6radiotrigger = hit.collider.GetComponentInParent<Event_6_RadioTrigger>();
            if (event6radiotrigger != null)
            {
                event6radiotrigger.ApagarRadio();

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
