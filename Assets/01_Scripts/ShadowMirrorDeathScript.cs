using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMirrorDeathScript : MonoBehaviour
{
    
    // Tiempo en segundos antes de que el objeto se destruya
    public float destructionDelay = 2.0f;

    void Start()
    {
        // Inicia la destrucción después del retraso especificado
        Destroy(gameObject, destructionDelay);
    }
}

