using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectivesManager : MonoBehaviour
{
    public enum ObjectiveStates
    {
        Objective1,
        Objective2,
        Objective3,
        Objective4,
        Objective5
    }

    public TextMeshProUGUI textForObjectives;
    public ObjectiveStates currentStates;

    private void Start()
    {
        currentStates = ObjectiveStates.Objective1;
        UpdateObjectiveUI();
    }

    private void Update()
    {
        switch (currentStates)
        {
            case ObjectiveStates.Objective1:
                Debug.Log("Whatever OBJ one does");

                UpdateObjectiveUI();

                //Trigger a function that sets obj 1

                break;

            case ObjectiveStates.Objective2:
                Debug.Log("Whatever OBJ two does");

                UpdateObjectiveUI();

                //Trigger a function that sets obj 2

                break;

            case ObjectiveStates.Objective3:
                Debug.Log("Whatever OBJ three does");

                UpdateObjectiveUI();

                //Trigger a function that sets obj 3

                break;

            case ObjectiveStates.Objective4:
                Debug.Log("Whatever OBJ four does");

                UpdateObjectiveUI();

                //Trigger a function that sets obj 4

                break;

            case ObjectiveStates.Objective5:
                Debug.Log("Whatever OBJ five does");

                UpdateObjectiveUI();

                //Trigger a funciton that sets obj 5

                break;
        }


        if(Input.GetKeyDown(KeyCode.O) & textForObjectives.enabled == true)
        {
            textForObjectives.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.O) & textForObjectives.enabled == false)
        {
            textForObjectives.enabled = true;
        }
    }

    public void UpdateObjectiveUI()
    {
        switch (currentStates)
        {
            case ObjectiveStates.Objective1:
                textForObjectives.text = "Objective: Example of obj 1";

                break;

            case ObjectiveStates.Objective2:
                textForObjectives.text = "Objective: Example of obj 2";

                break;

            case ObjectiveStates.Objective3:
                textForObjectives.text = "Objective: Example of obj 3";

                break;

            case ObjectiveStates.Objective4:
                textForObjectives.text = "Objective: Example of obj 4";

                break;

            case ObjectiveStates.Objective5:
                textForObjectives.text = "Objective: Example of obj 5";

                break;
        }



    }

}

        
