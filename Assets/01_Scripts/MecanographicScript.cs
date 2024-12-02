using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using Unity.VisualScripting;

public class MecanographicScript : MonoBehaviour
{
    public TextMeshProUGUI textToCopy;
    public TMP_InputField playerInputText;
    public TextMeshProUGUI feedbackText;
    [Space]

    public EventManager eventManager;
    public int minimumMecanoAmount;
    public int currentAmount;
    public int maximumMecanoAmout;
    public ComputerInteraction computerInteraction;

    private const string chars = "ABCDEFGHIJKLMNPQRSTUVWXYZ123456789abcdefghijklmnpqrstuvwxyz";

  
    private void Awake()
    {
       

        eventManager = FindAnyObjectByType<EventManager>();
    }
    private void Start()
    {
        GenerateRandomText();
    }
    void Update()
    {
        if(computerInteraction.isInInteraction)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                CheckText();
                
            }
        }
    }


    private void GenerateRandomText()
    {

        int eventCount = eventManager.eventCount;

        if (eventCount >= 0 && eventCount <= 2)
        {

            // Frases relacionadas con programaci�n de 8 caracteres
            string[] programmingSentences = {
                "private //",
                "for loop //",
                "try catch //",
                "function //",
                "variable //",
                "className //",
                "int main //",
                "return 0 //",
                "void func //",
                "namespace//",
                "Vector3//",
                "MonoBehaviour//"
            };

            int randomIndex = Random.Range(0, programmingSentences.Length);
            textToCopy.text = programmingSentences[randomIndex];
        }

        else if (eventCount >= 3 && eventCount <= 5)
        {
            // Generar el texto aleatorio
            string randomString = GetRandomString(4);
            // Crear frases que incluyan el texto aleatorio
            string[] predefinedSentences = {
                $"print(\"{randomString}\")",
                $"Output: {randomString}",
                $"Generated: {randomString}",


            };

            // Seleccionar frase predefinida aleatoria
            int randomIndex = Random.Range(0, predefinedSentences.Length);
            textToCopy.text = predefinedSentences[randomIndex];

        }

        else if (eventCount >= 6)
        {
            // Generar texto aleatorio
            string randomletters = GetRandomString(6);

            string StringForWeirdSentences = GetRandomString(2);

            string[] weirdsentences = {
                $"{StringForWeirdSentences}FeedMe{StringForWeirdSentences}",
                $"{StringForWeirdSentences}HelpMe{StringForWeirdSentences}",
                $"{StringForWeirdSentences}GET{StringForWeirdSentences}OUT{StringForWeirdSentences}",
                $"Get{StringForWeirdSentences}HIM{StringForWeirdSentences}away",
                $"Ineed{StringForWeirdSentences}to{StringForWeirdSentences}finish.",
            };

            bool chooseWeirdSentence = Random.value > 0.8f; // Este valor da un % de prob a las frases de arriba a aparecer. De 0 a 1.

            if (chooseWeirdSentence)
            {
                int randomIndexForWeirdSentences = Random.Range(0, weirdsentences.Length);
                textToCopy.text = weirdsentences[randomIndexForWeirdSentences];
            }
            else
            {
                textToCopy.text = randomletters;
            }


        }
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
