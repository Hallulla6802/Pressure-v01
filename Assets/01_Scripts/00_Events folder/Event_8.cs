using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class Event_8 : MonoBehaviour
{
    public AudioSource audioSource;
    public float audioDuration = 15f; // Duración en segundos
    public EventManager eventManager;
    public ObjectivesManager objMan;

    private BoxCollider event8Collider;


    private void Awake()
    {
        event8Collider = GetComponent<BoxCollider>();
        eventManager = FindObjectOfType<EventManager>();
        objMan = FindObjectOfType<ObjectivesManager>();
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
        objMan.currentStates =  ObjectivesManager.ObjectiveStates.GoToThePC;
        eventManager.currentEvent = EventsToTrigger.None;
        event8Collider.enabled = false;
    }
}