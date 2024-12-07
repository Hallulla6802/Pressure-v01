using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class Event_7 : MonoBehaviour
{
    public AudioSource audioSource;
    public float audioDuration = 15f; // Duración en segundos
    public EventManager eventManager;
    public ObjectivesManager objMan;

    private BoxCollider event7Collider;


    private void Awake()
    {
        event7Collider = GetComponent<BoxCollider>();
        eventManager = FindObjectOfType<EventManager>();
        objMan = FindObjectOfType<ObjectivesManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (audioSource != null)
            {
                event7Collider.enabled = false;
                audioSource.Play();
                StartCoroutine(StopAudioAfterDelay(audioDuration));
            }
        }
    }

    private IEnumerator StopAudioAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.Stop();
        objMan.currentStates = ObjectivesManager.ObjectiveStates.GoToThePC;
        eventManager.currentEvent = EventsToTrigger.None;
        event7Collider.enabled = false;
    }
}