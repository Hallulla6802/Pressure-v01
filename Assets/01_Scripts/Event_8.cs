using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_8 : MonoBehaviour
{
    public AudioSource audioSource;
    public float audioDuration = 20f; // Duración en segundos

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (audioSource != null)
            {
                audioSource.Play();
                StartCoroutine(StopAudioAfterDelay(audioDuration));
            }
        }
    }

    private IEnumerator StopAudioAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.Stop();
    }
}