using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_3_Lights : MonoBehaviour
{
    public GameObject lightsToTurnOn;
    public GameObject redDot;
    public bool isTrigger;
    public TextoInteractuarScript textoInteractuarScript;
    [SerializeField]private BoxCollider objectCollider;

    private void Awake()
    {
        objectCollider = GetComponent<BoxCollider>();
        textoInteractuarScript = FindObjectOfType<TextoInteractuarScript>();
        objectCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //Debug.Log("PlayerHasCollided");
            isTrigger = true;
            textoInteractuarScript.AbrirTextoInteractuar();


        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isTrigger)
        {
            lightsToTurnOn.SetActive(true);
            redDot.SetActive(false);
            objectCollider.enabled = false;
            textoInteractuarScript.CerrarTextoInteractuar();
            isTrigger = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTrigger = false;
            textoInteractuarScript.CerrarTextoInteractuar();
        }
    }
}
