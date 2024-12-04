using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_3 : MonoBehaviour
{
    public GameObject lightempty;
    public GameObject redDotForOutside;
 

    public bool lightsFixed;
    public GameObject pcScreen;
    private BoxCollider event3Collider;

    public AudioSource lucesapangadnoseAudio;

    private void Awake()
    {

        GameObject lucesapagadaObject = GameObject.Find("Light Switch Off");

        if (lucesapagadaObject != null)
        {
            lucesapangadnoseAudio = lucesapagadaObject.GetComponent<AudioSource>();
        }

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
            lucesapangadnoseAudio.Play();
            pcScreen.SetActive(false);
            lightempty.SetActive(false);
            redDotForOutside.SetActive(true);
            

            lightsFixed = false;
            event3Collider.enabled = false;
        }
    }
}
