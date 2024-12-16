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
    [Space]
    [Header("NPC")]
    [Space]
    public LocalizedString[] localizedDialogList;
    public TextMeshProUGUI dialogText;

    private int currentLineIndex = 0;

    [Space]

    public float typingSpeed = 0.05f;  // Speed of typing
    private bool isTyping = false;
    private Coroutine typingCoroutine;

    [Space]
    public AudioSource[] typingSounds; // Array of typing sounds
    public float soundInterval = 0.1f; // Interval between sound plays
    private Coroutine soundCoroutine; // Coroutine to manage sound playback

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
        if (isTyping)
        {
            CompleteTyping();
        }
        else if (currentLineIndex < localizedDialogList.Length)
        {
            if (spriteNextLine != null)
            {
                spriteNextLine.SetActive(false);
            }

            LocalizedString currentLine = localizedDialogList[currentLineIndex];
            typingCoroutine = StartCoroutine(TypeLocalizedLine(currentLine));
            currentLineIndex++;
        }
        else
        {
            CompleteDialog();
        }
    }

    // Typing out the localized dialog line and playing random sounds continuously
    private IEnumerator TypeLocalizedLine(LocalizedString line)
    {
        isTyping = true;
        dialogText.text = "";

        // Fetch localized text
        var asyncOperation = line.GetLocalizedStringAsync();
        yield return asyncOperation;

        string localizedText = asyncOperation.Result;

        // Start playing sounds while typing
        soundCoroutine = StartCoroutine(PlayTypingSoundContinuous());

        foreach (char letter in localizedText.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
        StopCoroutine(soundCoroutine); // Stop the sound coroutine once typing is complete

        if (spriteNextLine != null)
        {
            spriteNextLine.SetActive(true);
        }
    }

    // Continuously play a typing sound at intervals
    private IEnumerator PlayTypingSoundContinuous()
    {
        while (isTyping)
        {
            PlayRandomTypingSound();
            yield return new WaitForSeconds(soundInterval);
        }
    }

    // Play a random typing sound
    private void PlayRandomTypingSound()
    {
        if (typingSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, typingSounds.Length);
            AudioSource randomSound = typingSounds[randomIndex];

            // Play the selected sound
            if (!randomSound.isPlaying) // Only play if it's not already playing
            {
                randomSound.PlayOneShot(randomSound.clip);
            }
        }
        else
        {
            Debug.LogWarning("No typing sounds available!");
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

    #region SOUNDS DIALOG

    

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


