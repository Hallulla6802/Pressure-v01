using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MecanographicScript : MonoBehaviour
{
    public TextMeshProUGUI textToCopy;
    public TMP_InputField playerInputText;
    public TextMeshProUGUI feedbackText;

    private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";

    private void Start()
    {
        GenerateRandomText();
    }

    private void GenerateRandomText()
    {
        textToCopy.text = GetRandomString(6);
    }

    private string GetRandomString(int length)
    {
        char[] stringChars = new char[length];
        for (int i = 0; i < length; i++)
        {
            stringChars[i] = chars[Random.Range(0, chars.Length)];
        }
        return new string(stringChars);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Enter Key is called return????????????
        {
            CheckText();
        }
    }

    public void CheckText()
    {
        
        if (playerInputText.text == textToCopy.text)
        {
            feedbackText.text = "Correct!";
            feedbackText.color = Color.green;
        }
        else
        {
            feedbackText.text = "Try Again!";
            feedbackText.color = Color.red;
        }

        GenerateRandomText();

        playerInputText.text = "";
        
        
    }

}
