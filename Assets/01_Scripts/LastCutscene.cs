using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LastCutscene : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public CameraScript cameraScript;
    public ObjectivesManager objectivesManager;
   
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerMovement.canMove = false;
            cameraScript.canLook = false;
            objectivesManager.canSeeObj = false;
            
        }
    }
}
