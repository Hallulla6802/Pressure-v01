using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Tables;

public class DoorScript : MonoBehaviour
{
    public Animator doorAnimator;
    public string openAnimationName = "DoorOpen";
    public string closeAnimationName = "DoorClose";
    public float closeDelay = 2f;
    public bool isDoorOpen = false;
    [Space]
    public AudioSource closingDoorSound;
    public AudioSource openDoorSound;
    [Space]
    [Header("LOCALIZATION SETTINGS")]
    public string localizationKey = "";  // Localization key
    private LocalizedString currentLocalizedText;  // Store the localized string

    private void Start()
    {
        if (doorAnimator == null)
        {
            doorAnimator = GetComponent<Animator>();
        }

        // Initialize the localized string using the key
        currentLocalizedText = new LocalizedString();
        currentLocalizedText.TableReference = "Table1";
        currentLocalizedText.TableEntryReference = localizationKey;  // Localization key
    }

    // Function to refresh localized text when language is switched
    private void RefreshLocalizedText()
    {
        currentLocalizedText = new LocalizedString
        {
            TableReference = "Table1",
            TableEntryReference = localizationKey
        };
    }

    public void InteractWithHandle()
    {
        if (!isDoorOpen)
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        openDoorSound.Play();
        doorAnimator.Play(openAnimationName);
        isDoorOpen = true;
        Invoke("CloseDoor", closeDelay);
    }

    private void CloseDoor()
    {
        if (isDoorOpen)
        {
            closingDoorSound.Play();
            doorAnimator.Play(closeAnimationName);
            isDoorOpen = false;
        }
    }

    
    public string GetLocalizedPropText()
    {
        return currentLocalizedText.GetLocalizedString();
    }
}
