using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LastCutscene : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public CameraScript cameraScript;
    public ObjectivesManager objectivesManager;

    [Space]
    public GameObject blackScreen;

    [Space]
    public AudioSource noise;
    public AudioSource bodythumpNoise;
    public AudioSource fanAudio;

    [Space]
    public Button UploadProjectButton;


    private void Start()
    {
        blackScreen.SetActive(false);
        UploadProjectButton.interactable = false;
    }

    public void EndGameFunction()
    {
        playerMovement.canMove = false;
        cameraScript.canLook = false;
        objectivesManager.canSeeObj = false;

        blackScreen.SetActive(true);

        noise.Stop();
        fanAudio.Stop();

        bodythumpNoise.Play();
    }

}
