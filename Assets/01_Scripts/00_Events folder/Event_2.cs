using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class Event_2 : MonoBehaviour
{
    public AudioSource audioSource;
    public float audioDuration; // Duración en segundos

    private BoxCollider event2Collider;

    public EventManager eventManager;

    private void Awake()
    {
        event2Collider = GetComponent<BoxCollider>();
        eventManager = FindObjectOfType<EventManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (audioSource != null)
            {
                event2Collider.enabled = false;
                audioSource.Play();
                StartCoroutine(StopAudioAfterDelayEvent9(audioDuration));
            }
        }
    }

    private IEnumerator StopAudioAfterDelayEvent9(float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.Stop();

        event2Collider.enabled = false;
        eventManager.currentEvent = EventsToTrigger.None;
    }
}
