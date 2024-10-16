using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_5 : MonoBehaviour
{
    public AudioSource tvSound;
    public GameObject tvTrigger;

    private BoxCollider event5Collider;

    private void Awake()
    {
        event5Collider = GetComponent<BoxCollider>();
        tvTrigger.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tvSound.Play();

            event5Collider.enabled = false;
            tvTrigger.SetActive(true);
        }
    }
}
