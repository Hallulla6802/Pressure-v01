using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

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
        CloseTheDoor,
        InvestigateSteps,
        InvestigateFight,
        UploadProject
    }

    public TextMeshProUGUI textForObjectives;
    public GameObject BeeperToHide;
    public GameObject animatedArm;

    [Space]

    public ObjectiveStates currentStates;
    public bool canSeeObj = true;

    [Space]
    [Header("Localization strings")]
    [Space]

    //Variables for localization
    public LocalizedString goToThePCKey;
    public LocalizedString workingOnPCKey;
    public LocalizedString investigateMicrowaveKey;
    public LocalizedString investigateDoorKnockingKey;
    public LocalizedString fixTheLightsKey;
    public LocalizedString turnOffTheWaterKey;
    public LocalizedString turnOffTheTVKey;
    public LocalizedString fixTheRadioKey;
    public LocalizedString closeTheDoorKey;
    public LocalizedString investigateStepsKey;
    public LocalizedString investigateFigthKey;
    public LocalizedString uploadProjectKey;

    private void Start()
    {
        currentStates = ObjectiveStates.GoToThePC;

        BeeperToHide.SetActive(false);
        animatedArm.SetActive(true);
        
        UpdateActiveText();

    }

    private void Update()
    {
        UpdateActiveText();

        if (Input.GetKeyDown(KeyCode.Q) & BeeperToHide.activeSelf == true)
        {
            BeeperToHide.SetActive(false);
            animatedArm.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Q) & BeeperToHide.activeSelf == false)
        {
            if(canSeeObj == true)
            {
                BeeperToHide.SetActive(true);
                animatedArm.SetActive(false);
            }
        }
    }

    private void UpdateActiveText()
    {
        LocalizedString localizedKey = null;

        switch (currentStates)
        {
            case ObjectiveStates.GoToThePC:
                localizedKey = goToThePCKey;
                break;
            case ObjectiveStates.WorkingOnPC:
                localizedKey = workingOnPCKey;
                break;
            case ObjectiveStates.InvestigateMicrowave:
                localizedKey = investigateMicrowaveKey;
                break;
            case ObjectiveStates.InvestigateDoorKnocking:
                localizedKey = investigateDoorKnockingKey;
                break;
            case ObjectiveStates.FixTheLights:
                localizedKey = fixTheLightsKey;
                break;
            case ObjectiveStates.TurnOffTheWater:
                localizedKey = turnOffTheWaterKey;
                break;
            case ObjectiveStates.TurnOffTheTV:
                localizedKey = turnOffTheTVKey;
                break;
            case ObjectiveStates.FixTheRadio:
                localizedKey = fixTheRadioKey;
                break;
            case ObjectiveStates.CloseTheDoor:
                localizedKey = closeTheDoorKey;
                break;
            case ObjectiveStates.InvestigateSteps:
                localizedKey = investigateStepsKey;
                break;
            case ObjectiveStates.InvestigateFight:
                localizedKey = investigateFigthKey;
                break;
            case ObjectiveStates.UploadProject:
                localizedKey = uploadProjectKey;
                break;
        }

        if (localizedKey != null)
        {
            localizedKey.GetLocalizedStringAsync().Completed += handle =>
            {
                if (handle.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
                {
                    textForObjectives.text = handle.Result;
                }
                else
                {
                    Debug.LogError($"Failed to fetch localized text for key: {localizedKey}");
                }
            };
        }
    }

    public void ChangeObjective(ObjectiveStates newObjective)
    {
        currentStates = newObjective;
        UpdateActiveText();
    }

}

        
