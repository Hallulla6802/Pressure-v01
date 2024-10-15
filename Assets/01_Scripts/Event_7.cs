using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_7 : MonoBehaviour
{
    public GameObject shadowGuy;
    public float cooldown;

    private void Start()
    {
        shadowGuy.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(cooldownForGuy());
        }
    }

    private IEnumerator cooldownForGuy()
    {
        shadowGuy.SetActive(true);
        yield return new WaitForSeconds(cooldown);
        shadowGuy.SetActive(false);
    }
}
