using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Localization;

public class TextSequence : MonoBehaviour
{
    public TMP_Text textElement;
    public List<string> localizationKeys; // Keys for localized strings
    public float typingSpeed = 0.05f;
    public float fastTypingSpeed = 0.01f; // New variable for faster typing speed
    public Animator bs_Animator;
    private int currentTextIndex = 0;
    private bool isTyping = false;
    private Coroutine typingCoroutine;

    public AudioSource typingAudioSource;

    public void StartContextScreen()
    {

        if (localizationKeys.Count == 0)
        {
            Debug.LogError("No localization keys provided.");
            return;
        }

        textElement.text = "";
        textElement.gameObject.SetActive(false);

        typingCoroutine = StartCoroutine(ShowText(localizationKeys[currentTextIndex]));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isTyping)
        {
            NextText();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SkipToLastText();
        }
    }

    IEnumerator ShowText(string localizationKey)
    {
        isTyping = true;
        textElement.gameObject.SetActive(true);
        textElement.text = "";

        Debug.Log("Fetching localized text for key: " + localizationKey);

        // Fetch the localized string
        var localizedString = new LocalizedString("Table1", localizationKey);
        var handle = localizedString.GetLocalizedStringAsync();

        // Wait until the handle completes
        yield return handle;

        if (handle.Status != UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
        {
            Debug.LogError("Failed to fetch localized text for key: " + localizationKey);
            yield break;
        }

        string localizedText = handle.Result;
        Debug.Log("Starting to type text: " + localizedText);

        if (typingAudioSource != null && !typingAudioSource.isPlaying)
        {
            typingAudioSource.Play();
        }

        for (int i = 0; i < localizedText.Length; i++)
        {
            textElement.text += localizedText[i];

            // Adjust typing speed based on mouse button hold
            float currentTypingSpeed = Input.GetMouseButton(0) ? fastTypingSpeed : typingSpeed;
            yield return new WaitForSeconds(currentTypingSpeed);
        }

        Debug.Log("Finished typing text: " + localizedText);
        isTyping = false;

        if (typingAudioSource != null && typingAudioSource.isPlaying)
        {
            typingAudioSource.Stop();
        }
    }

    void NextText()
    {
        Debug.Log("Mouse clicked, advancing to next text.");

        if (currentTextIndex + 1 < localizationKeys.Count)
        {
            currentTextIndex++;
            typingCoroutine = StartCoroutine(ShowText(localizationKeys[currentTextIndex]));
        }
        else
        {
            Debug.Log("No more texts to show.");
            bs_Animator.Play("GameFadeOut");
        }
    }

    void SkipToLastText()
    {
        Debug.Log("Space pressed");
        bs_Animator.Play("GameFadeOut");

        if (typingAudioSource != null && typingAudioSource.isPlaying)
        {
            typingAudioSource.Stop();
        }

        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
    }
}

