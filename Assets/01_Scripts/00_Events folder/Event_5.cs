using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_5 : MonoBehaviour
{
    public AudioSource tvSound;

    public GameObject tvObj;
    private BoxCollider event5Collider;

    private void Awake()
    {
        event5Collider = GetComponent<BoxCollider>();
  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tvSound.Play();
            tvObj.SetActive(true);
            event5Collider.enabled = false;
           
        }
    }
}
