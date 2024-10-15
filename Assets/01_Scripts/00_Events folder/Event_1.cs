using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_1 : MonoBehaviour
{
    public AudioSource audioSource;
    public float audioDuration; // Duración en segundos

    private BoxCollider event1collider;

    private void Awake()
    {
        event1collider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (audioSource != null)
            {
                event1collider.enabled = false;
                audioSource.Play();
                StartCoroutine(StopAudioAfterDelayEvent9(audioDuration));
            }
        }
    }

    private IEnumerator StopAudioAfterDelayEvent9(float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.Stop();
        
        event1collider.enabled = false;
    }
}