using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectivesManager : MonoBehaviour
{
    public enum ObjectiveStates
    {
        GoToThePC,
        WorkingOnPC,
        InvestigateSound,
        Objective4,
        Objective5
    }

    public TextMeshPro textForObjectives;
    public GameObject BeeperToHide;
    [Space]
    public ObjectiveStates currentStates;

    private void Start()
    {
        currentStates = ObjectiveStates.GoToThePC;
        UpdateObjectiveUI();
    }

    private void Update()
    {
        switch (currentStates)
        {
            case ObjectiveStates.GoToThePC:
                //Debug.Log("Whatever OBJ one does");

                UpdateObjectiveUI();

                //Trigger a function that sets obj 1

                break;

            case ObjectiveStates.WorkingOnPC:
                //Debug.Log("Whatever OBJ two does");

                UpdateObjectiveUI();

                //Trigger a function that sets obj 2

                break;

            case ObjectiveStates.InvestigateSound:
                //Debug.Log("Whatever OBJ three does");

                UpdateObjectiveUI();

                //Trigger a function that sets obj 3

                break;

            case ObjectiveStates.Objective4:
                //Debug.Log("Whatever OBJ four does");

                UpdateObjectiveUI();

                //Trigger a function that sets obj 4

                break;

            case ObjectiveStates.Objective5:
                //Debug.Log("Whatever OBJ five does");

                UpdateObjectiveUI();

                //Trigger a funciton that sets obj 5

                break;
        }


        if(Input.GetKeyDown(KeyCode.O) & BeeperToHide.activeSelf == true)
        {
            BeeperToHide.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.O) & BeeperToHide.activeSelf == false)
        {
            BeeperToHide.SetActive(true);
        }
    }

    public void UpdateObjectiveUI()
    {
        switch (currentStates)
        {
            case ObjectiveStates.GoToThePC:
                textForObjectives.text = "Ve a tu habitacion para trabajar.";

                break;

            case ObjectiveStates.WorkingOnPC:
                textForObjectives.text = "Trabajando en el PC";

                break;

            case ObjectiveStates.InvestigateSound:
                textForObjectives.text = "Ve a investigar el ruido, no podemos concentrarnos asi.";

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

        
