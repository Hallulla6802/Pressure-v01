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
        InvestigateMicrowave,
        InvestigateDoorKnocking,
        FixTheLights,
        TurnOffTheWater,
        TurnOffTheTV,
        FixTheRadio,
        CloseTheDoor
    }

    public TextMeshPro textForObjectives;
    public GameObject BeeperToHide;
    [Space]
    public ObjectiveStates currentStates;

    private void Start()
    {
        currentStates = ObjectiveStates.GoToThePC;

        BeeperToHide.SetActive(false);
        
    }

    private void Update()
    {
        switch (currentStates)
        {
            case ObjectiveStates.GoToThePC:

                textForObjectives.text = "Ve a tu habitacion para trabajar.";

                break;

            case ObjectiveStates.WorkingOnPC:

                textForObjectives.text = "Sigue trabajando en el computador.";

                break;

            case ObjectiveStates.InvestigateMicrowave:

                textForObjectives.text = "Apaga el microondas en la cocina.";

                break;

            case ObjectiveStates.InvestigateDoorKnocking:

                textForObjectives.text = "Revisa quien esta tocando la puerta en la entrada.";

                break;

            case ObjectiveStates.FixTheLights:

                textForObjectives.text = "Arregla las luces afuera de el hogar.";

                break;

            case ObjectiveStates.TurnOffTheWater:

                textForObjectives.text = "Cierra el grifo de agua en el baño.";

                break;

            case ObjectiveStates.TurnOffTheTV:

                textForObjectives.text = "Apaga el Televisor en la sala de estar.";

                break;

            case ObjectiveStates.FixTheRadio:

                textForObjectives.text = "Arregla la radio, nos concentraremos mejor.";

                break;

            case ObjectiveStates.CloseTheDoor:

                textForObjectives.text = "Investiga quien abrio la puerta.";

                break;
        }


        if (Input.GetKeyDown(KeyCode.O) & BeeperToHide.activeSelf == true)
        {
            BeeperToHide.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.O) & BeeperToHide.activeSelf == false)
        {
            BeeperToHide.SetActive(true);
        }
    }

}

        
