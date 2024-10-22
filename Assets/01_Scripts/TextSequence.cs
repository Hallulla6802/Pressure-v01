using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextSequence : MonoBehaviour
{
    public List<TMP_Text> textElements;         
    public List<string> fullTextStrings;        
    public float typingSpeed = 0.05f;           

    private int currentTextIndex = 0;           
    private bool isTyping = false;              

    private void Start()
    {
        
        if (textElements.Count != fullTextStrings.Count)
        {
            Debug.LogError("Mismatch between text elements and full text strings! Please ensure both lists are the same size.");
            return;
        }

        
        foreach (var text in textElements)
        {
            text.text = "";  
            text.gameObject.SetActive(false);  
        }

       
        if (textElements.Count > 0)
        {
            StartCoroutine(ShowText(textElements[currentTextIndex], fullTextStrings[currentTextIndex]));
        }
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && !isTyping)
        {
            NextText();
        }
    }

    IEnumerator ShowText(TMP_Text text, string fullText)
    {
        isTyping = true;  
        text.gameObject.SetActive(true);  
        text.text = "";  

        Debug.Log("Starting to type text: " + fullText);

        
        for (int i = 0; i < fullText.Length; i++)
        {
            text.text += fullText[i];  
            yield return new WaitForSeconds(typingSpeed);  
        }

        Debug.Log("Finished typing text: " + fullText);
        isTyping = false;  
    }

    void NextText()
    {
        Debug.Log("Mouse clicked, advancing to next text.");

        
        textElements[currentTextIndex].gameObject.SetActive(false);

        
        if (currentTextIndex + 1 < textElements.Count)
        {
            currentTextIndex++;
            StartCoroutine(ShowText(textElements[currentTextIndex], fullTextStrings[currentTextIndex]));
        }
        else
        {
            Debug.Log("No more texts to show.");
        }
    }
}
