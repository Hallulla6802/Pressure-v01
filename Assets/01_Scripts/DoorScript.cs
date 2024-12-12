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
        currentLocalizedText.TableReference = "Table1"; // Name of your table (e.g., "Main")
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
        doorAnimator.Play(openAnimationName);
        isDoorOpen = true;
        Invoke("CloseDoor", closeDelay);
    }

    private void CloseDoor()
    {
        if (isDoorOpen)
        {
            doorAnimator.Play(closeAnimationName);
            isDoorOpen = false;
        }
    }

    
    public string GetLocalizedPropText()
    {
        return currentLocalizedText.GetLocalizedString();
    }
}
