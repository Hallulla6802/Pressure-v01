using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;
using TMPro;

public class Event_2_CollaiderDoor : MonoBehaviour
{
    public bool isTrigger;

    public GameObject npcpanel;
    public GameObject NPCgameobject;
    [Space]
    public AudioSource knocksound;
    public Outline objOutline;
    public ObjectivesManager objMan;
    public EventManager eventManager;
    public PrincipalDoorScript doorScript;
    public PlayerMovement playerMove;
    [Space]
    //Variables para el dialogo del NPC
    public string[] dialogesList;
    public TextMeshProUGUI dialogText;

    private int currentLineIndex = 0;
    [Space]
    public float typingSpeed = 0.5f;

    private bool isTyping = false;
    private Coroutine typíngCoroutine;

    private void Awake()
    {

        npcpanel.SetActive(false);

        
        playerMove = FindObjectOfType<PlayerMovement>();
        eventManager = FindObjectOfType<EventManager>();
        objMan = FindObjectOfType<ObjectivesManager>();
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
        knocksound.Stop();
        StartDialoge();

        playerMove.canMove = false;

        npcpanel.SetActive(true);

        objOutline.enabled = false;
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
                dialogText.text = dialogesList[currentLineIndex];
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
    }

    private void CompleteTyping()
    {
        if (typíngCoroutine != null)
        {
            StopCoroutine(typíngCoroutine);
        }
        dialogText.text = dialogesList[currentLineIndex - 1]; //Muestra el texto completo.
        isTyping = false;

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
        playerMove.canMove = true;

        NPCgameobject.SetActive(false);
        eventManager.currentEvent = EventsToTrigger.None;
        objMan.currentStates = ObjectivesManager.ObjectiveStates.GoToThePC;
    }
  
}
