using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_7 : MonoBehaviour
{
    public GameObject shadowGuy;


    public BoxCollider event7collider;


    private void Awake()
    {
        event7collider = GetComponent<BoxCollider>();

        shadowGuy.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !shadowGuy.activeSelf)
        {
            if (Random.Range(0f, 1f) <= 0.5f)
            {
                //event7collider.enabled = false;
                shadowGuy.SetActive(true);
                //StartCoroutine(cooldownForGuy());
            }
               
        }
    }

    public void cooldownForGuy()
    {
        //shadowGuy.SetActive(true);
       // yield return new WaitForSeconds(cooldown);
        shadowGuy.SetActive(false);
        //event7collider.enabled = true;

    }
}
