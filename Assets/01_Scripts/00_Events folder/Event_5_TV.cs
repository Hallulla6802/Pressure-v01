using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_5_TV : MonoBehaviour
{
    public AudioSource tvSound;
    public TextoInteractuarScript textoInteractuarScript;
    private BoxCollider event5Collider;
    public bool isTrigger;

    private void Awake()
    {
        textoInteractuarScript = FindObjectOfType<TextoInteractuarScript>();
        event5Collider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isTrigger = true;
            textoInteractuarScript.AbrirTextoInteractuar();
        }
    }

    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.E) && isTrigger)
       {
            tvSound.Stop();
            event5Collider.enabled = false;
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
