using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LastCutscene : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public CameraScript cameraScript;
    public ObjectivesManager objectivesManager;

    public Camera playerCamera;
    public Transform playerArm;
    public Animator camAnim;

    private void Awake()
    {
        camAnim = FindObjectOfType<Animator>();
        camAnim.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {

            playerMovement.canMove = false;
            cameraScript.canLook = false;
            objectivesManager.canSeeObj = false;

            playerArm.gameObject.SetActive(false);
            camAnim.enabled = true;

            
            
        }
    }


}
