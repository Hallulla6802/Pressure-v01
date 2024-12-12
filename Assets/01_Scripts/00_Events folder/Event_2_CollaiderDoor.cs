using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Localization;

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

    // Variables for the NPC dialog
    public LocalizedString[] localizedDialogList;
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
        if (npcpanel.activeSelf && Input.GetMouseButtonDown(0))
        {
            ShowDialogLine();
        }
    }

    public void InteractuarConLaPuertaParaNPC()
    {
        knocksound.Stop();
        StartDialog();
        if (playerAnimator.GetBool("IsMoving"))
        {
            playerAnimator.SetBool("IsMoving", false);
        }
        playerMove.canMove = false;
        cameraScript.canLook = false;
        playerCamera.enabled = false;
        doorCamera.enabled = true;
        doorCollider.enabled = false;
        crosshair.enabled = false;

        npcpanel.SetActive(true);
        isTrigger = false;
    }

    #region DIALOG SECTION

    public void StartDialog()
    {
        if (localizedDialogList.Length > 0)
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
        if (currentLineIndex < localizedDialogList.Length)
        {
            if (isTyping)
            {
                CompleteTyping();
            }
            else
            {
                if (spriteNextLine != null)
                {
                    spriteNextLine.SetActive(false);
                }

                LocalizedString currentLine = localizedDialogList[currentLineIndex];
                typingCoroutine = StartCoroutine(TypeLocalizedLine(currentLine)); // Start typing coroutine
                currentLineIndex++;
            }
        }
        else
        {
            CompleteDialog();
        }
    }

    private IEnumerator TypeLocalizedLine(LocalizedString line)
    {
        isTyping = true;
        dialogText.text = "";

        // Search localized text
        var asyncOperation = line.GetLocalizedStringAsync();
        yield return asyncOperation;

        string localizedText = asyncOperation.Result;

        foreach (char letter in localizedText.ToCharArray())
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
        var currentLine = localizedDialogList[currentLineIndex - 1];
        currentLine.GetLocalizedStringAsync().Completed += handle =>
        {
            dialogText.text = handle.Result; // Show full text
        };

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
