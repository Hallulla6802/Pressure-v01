using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class MecanographicScript : MonoBehaviour
{
    public TextMeshProUGUI textToCopy;
    public TMP_InputField playerInputText;
    public TextMeshProUGUI feedbackText;
    [Space]

    public int minimumMecanoAmount;
    public int currentAmount;
    public int maximumMecanoAmout;

    private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";

    private void Start()
    {
        GenerateRandomText();
    }

    private void GenerateRandomText()
    {
        textToCopy.text = GetRandomString(8);
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

    public void CheckText()
    {
        if (playerInputText.text == textToCopy.text)
        {
            currentAmount++;

            feedbackText.text = "Correct!";
            feedbackText.color = Color.green;

            if(currentAmount >= maximumMecanoAmout)
            {
                currentAmount = maximumMecanoAmout;
            }
           
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
