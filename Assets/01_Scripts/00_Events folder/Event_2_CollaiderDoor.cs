using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;
using TMPro;
using UnityEngine.UI;

public class Event_2_CollaiderDoor : MonoBehaviour
{
    public PlayerMovement playerMove;
    public CameraScript cameraScript;
    public Camera playerCamera;
    public Camera doorCamera;

    public bool isTrigger;

    public GameObject npcpanel;
    public GameObject NPCgameobject;
    [Space]
    public AudioSource knocksound;
    public Outline objOutline;
    public ObjectivesManager objMan;
    public EventManager eventManager;
    public PrincipalDoorScript doorScript;
    
    public Transform playerTransform;
   
    public Transform cameraTransform;
    public Animator playerAnimator;
    public BoxCollider doorCollider;
    public Image crosshair;
    public GameObject spriteNextLine;
    [Space]
    //Variables para el dialogo del NPC
    public string[] dialogesList;
    public TextMeshProUGUI dialogText;

    private int currentLineIndex = 0;
    [Space]
    public float typingSpeed = 0.5f;

    private bool isTyping = false;
    private Coroutine typingCoroutine;

    private void Awake()
    {

        npcpanel.SetActive(false);

        
        playerMove = FindObjectOfType<PlayerMovement>();
        eventManager = FindObjectOfType<EventManager>();
        objMan = FindObjectOfType<ObjectivesManager>();

        if (spriteNextLine != null)
        {
            spriteNextLine.SetActive(false);
        }
    }

    private void Update()
    {
        if(npcpanel.activeSelf && Input.GetMouseButtonDown(0))
        {
            ShowDialogLine();
        }
    }

    public void InteractuarConLaPuertaParaNPC()
    {
        //Vector3 playerModelTargetLocation = new Vector3(NPCgameobject.transform.position.x, playerTransform.transform.position.y, NPCgameobject.transform.position.z);
        knocksound.Stop();
        StartDialoge();
        if(playerAnimator.GetBool("IsMoving"))
        {
            playerAnimator.SetBool("IsMoving", false);
        }
        playerMove.canMove = false;
        //playerTransform.LookAt(playerModelTargetLocation);
        //cameraTransform.rotation =  Quaternion.Euler(0f, 180f, 0f);
        cameraScript.canLook = false;
        playerCamera.enabled = false;
        doorCamera.enabled = true;
        doorCollider.enabled = false;
        crosshair.enabled = false;

        npcpanel.SetActive(true);
        isTrigger = false;

    }

    #region DIALOGE SECTION

    public void StartDialoge()
    {
        if(dialogesList.Length > 0)
        {
            currentLineIndex = 0;
            ShowDialogLine();
        }
        else
        {
            CompleteDialog();
        }
    }

    public void ShowDialogLine()
    {
        if (currentLineIndex < dialogesList.Length)
        {
            if(isTyping)
            {
                CompleteTyping();
            }
            else
            {
                if (spriteNextLine != null)
                {
                    spriteNextLine.SetActive(false);
                }

                string currentLine = dialogesList[currentLineIndex];
                typingCoroutine = StartCoroutine(TypeLine(currentLine)); // Inicia la corrutina.
                currentLineIndex++;
            }
            
        }
        else
        {
            CompleteDialog();
        }
    }

    private IEnumerator TypeLine(string line)
    {
        isTyping = true;
        dialogText.text = "";

        foreach (char letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;

        if (spriteNextLine != null)
        {
            spriteNextLine.SetActive(true);
        }
    }

    private void CompleteTyping()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        dialogText.text = dialogesList[currentLineIndex - 1]; //Muestra el texto completo.
        isTyping = false;

        if (spriteNextLine != null)
        {
            spriteNextLine.SetActive(true);
        }
    }

    #endregion

    public void CompleteDialog()
    {
        npcpanel.SetActive(false);
        EventoResuelto();
        doorScript.CloseDoor();
    }

    public void EventoResuelto()
    {
        StartCoroutine(DisableNPCGameObject());
        playerMove.canMove = true;
        cameraScript.canLook = true;
        doorCamera.enabled = false;
        playerCamera.enabled = true;
        doorCollider.enabled = true;
        crosshair.enabled = true;
        eventManager.currentEvent = EventsToTrigger.None;
        objMan.currentStates = ObjectivesManager.ObjectiveStates.GoToThePC;
    }
    IEnumerator DisableNPCGameObject()
    {
        yield return new WaitForSeconds(0.5f);
        NPCgameobject.SetActive(false);
    }
}
