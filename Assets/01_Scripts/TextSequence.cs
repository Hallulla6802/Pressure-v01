using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextSequence : MonoBehaviour
{
    public TMP_Text textElement;         
    public List<string> fullTextStrings; 
    public float typingSpeed = 0.05f;    
    private int currentTextIndex = 0;    
    private bool isTyping = false;       

    private void Start()
    {
        
        if (fullTextStrings.Count == 0)
        {
            Debug.LogError("No text strings to display");
            return;
        }

        
        textElement.text = "";
        textElement.gameObject.SetActive(false);

        
        StartCoroutine(ShowText(fullTextStrings[currentTextIndex]));
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && !isTyping)
        {
            NextText();
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
            yield return new WaitForSeconds(typingSpeed);  
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
        }
    }
}
