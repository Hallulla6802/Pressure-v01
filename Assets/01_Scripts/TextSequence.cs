using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextSequence : MonoBehaviour
{
    public TMP_Text textElement;
    public List<string> fullTextStrings;
    public float typingSpeed = 0.05f;
    public float fastTypingSpeed = 0.01f;  // New variable for faster typing speed

    private ChangeSceneManager changeSceneMan;
    private int currentTextIndex = 0;
    private bool isTyping = false;
    private Coroutine typingCoroutine;

    public void StartContextScreen()
    {
        changeSceneMan = FindObjectOfType<ChangeSceneManager>();

        if (fullTextStrings.Count == 0)
        {
            Debug.LogError("No text strings to display");
            return;
        }

        textElement.text = "";
        textElement.gameObject.SetActive(false);

        typingCoroutine = StartCoroutine(ShowText(fullTextStrings[currentTextIndex]));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isTyping)
        {
            NextText();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            SkipToLastText();
        }
    }

    IEnumerator ShowText(string fullText)
    {
        isTyping = true;
        textElement.gameObject.SetActive(true);
        textElement.text = "";

        Debug.Log("Starting to type text: " + fullText);

        for (int i = 0; i < fullText.Length; i++)
        {
            textElement.text += fullText[i];

            // Mouse button hold
            float currentTypingSpeed = Input.GetMouseButton(0) ? fastTypingSpeed : typingSpeed;
            yield return new WaitForSeconds(currentTypingSpeed);
        }

        Debug.Log("Finished typing text: " + fullText);
        isTyping = false;
    }

    void NextText()
    {
        Debug.Log("Mouse clicked, advancing to next text.");

        if (currentTextIndex + 1 < fullTextStrings.Count)
        {
            currentTextIndex++;
            StartCoroutine(ShowText(fullTextStrings[currentTextIndex]));
        }
        else
        {
            Debug.Log("No more texts to show.");

            changeSceneMan.GoToGame();
        }
    }
    void SkipToLastText()
    {
        Debug.Log("Space pressed");

        changeSceneMan.GoToGame();
        StopCoroutine(ShowText(fullTextStrings[currentTextIndex]));
    }
}
