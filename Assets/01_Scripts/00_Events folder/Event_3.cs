using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_3 : MonoBehaviour
{
    public GameObject lightempty;
    public GameObject redDotForOutside;
    public GameObject transformador;

    public bool lightsFixed;
    public GameObject pcScreen;
    private BoxCollider event3Collider;

    private void Awake()
    {
        event3Collider = GetComponent<BoxCollider>();

        transformador.SetActive(false);
        lightsFixed = false;
        event3Collider.enabled = true;
    }

    private void Start()
    {
        lightempty.SetActive(true);
        redDotForOutside.SetActive(false);
    }
        

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            pcScreen.SetActive(false);
            lightempty.SetActive(false);
            redDotForOutside.SetActive(true);
            transformador.SetActive(true);

            lightsFixed = false;
            event3Collider.enabled = false;
        }
    }
}
