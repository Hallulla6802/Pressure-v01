using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_3 : MonoBehaviour
{
    public GameObject lightempty;
    public GameObject redDotForOutside;
 

    public bool lightsFixed;
    public GameObject pcScreen;
    private BoxCollider event3Collider;
    public Material m_LightBulb;
    public Material m_Bulb;

    public AudioSource lucesapangadnoseAudio;

    private void Awake()
    {

        GameObject lucesapagadaObject = GameObject.Find("Light Switch Off");

        if (lucesapagadaObject != null)
        {
            lucesapangadnoseAudio = lucesapagadaObject.GetComponent<AudioSource>();
        }

        event3Collider = GetComponent<BoxCollider>();

      
        lightsFixed = false;
        event3Collider.enabled = true;
    }

    private void Start()
    {
        lightempty.SetActive(true);
        redDotForOutside.SetActive(false);
    }
        

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            lucesapangadnoseAudio.Play();
            pcScreen.SetActive(false);
            lightempty.SetActive(false);
            DisableEmission(m_Bulb);
            DisableEmission(m_LightBulb);                   
            lightsFixed = false;
            event3Collider.enabled = false;
            redDotForOutside.SetActive(true);
        }
    }
    void DisableEmission(Material material)
    {
        // Verifica si el material tiene un shader con emisión
        if (material.HasProperty("_EmissionColor"))
        {
            // Apaga la emisión configurando el color a negro
            material.SetColor("_EmissionColor", Color.black);
            
            // Asegúrate de desactivar la palabra clave de emisión
            material.DisableKeyword("_EMISSION");
        }
    }
}
