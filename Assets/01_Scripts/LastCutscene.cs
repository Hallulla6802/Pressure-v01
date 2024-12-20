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
    public ComputerInteraction computerInteraction;

    [Space]
    public Animator blackScreen;

    [Space]
    public AudioSource noise;
    public AudioSource bodythumpNoise;
    public AudioSource fanAudio;
    public AudioSource mouseClick;

    [Space]
    public Button UploadProjectButton;
    public GameObject buttonUpload;

    public ChangeSceneManager changeScene;

    public void EndGameFunction()
    {
        playerMovement.canMove = false;
        cameraScript.canLook = false;
        objectivesManager.canSeeObj = false;

        blackScreen.Play("FinishGame");

        noise.Stop();
        fanAudio.Stop();
        mouseClick.mute = true;
        bodythumpNoise.Play();
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
        StartCoroutine(ChangeScene());
    }

    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(3f);
        changeScene.GoToMenu();
    }

}
