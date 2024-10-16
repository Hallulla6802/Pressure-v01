using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_3 : MonoBehaviour
{
    public GameObject lightempty;
    public GameObject redDotForOutside;
    public bool lightsFixed;

    private BoxCollider event3Collider;

    private void Awake()
    {
        event3Collider = GetComponent<BoxCollider>();

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
            lightempty.SetActive(false);
            redDotForOutside.SetActive(true);

            lightsFixed = false;
            event3Collider.enabled = false;
        }
    }
}
