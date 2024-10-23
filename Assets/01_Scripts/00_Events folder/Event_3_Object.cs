using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_3_Lights : MonoBehaviour
{
    public GameObject lightsToTurnOn;
    public GameObject redDot;
    public GameObject pcScreen;
  
    [SerializeField]private BoxCollider objectCollider;

    private void Awake()
    {
        objectCollider = GetComponent<BoxCollider>();
    
        objectCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            pcScreen.SetActive(true);
            lightsToTurnOn.SetActive(true);
            redDot.SetActive(false);
            objectCollider.enabled = false;

        }
    }


}
