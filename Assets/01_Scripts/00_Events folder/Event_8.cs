using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_8 : MonoBehaviour
{
    public AudioSource audioSource;
    public float audioDuration = 20f; // Duración en segundos

    private BoxCollider event8Collider;


    private void Awake()
    {
        event8Collider = GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (audioSource != null)
            {
                event8Collider.enabled = false;
                audioSource.Play();
                StartCoroutine(StopAudioAfterDelay(audioDuration));
            }
        }
    }

    private IEnumerator StopAudioAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.Stop();

        event8Collider.enabled = false;
    }
}