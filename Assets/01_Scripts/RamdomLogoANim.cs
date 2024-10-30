using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamdomLogoANim : MonoBehaviour
{
     // Referencia al Animator
    public Animator logoAnimator;

    // Rango de tiempo aleatorio (en segundos)
    public float minTime = 2f;
    public float maxTime = 20f;

    void Start()
    {
        // Inicia la corrutina
        StartCoroutine(PlayAnimationWithDelay());
    }

    IEnumerator PlayAnimationWithDelay()
    {
        while(true)
        {
            // Genera un tiempo de retraso aleatorio entre minTime y maxTime
            float randomDelay = Random.Range(minTime, maxTime);

            // Espera el tiempo aleatorio antes de reproducir la animación
            yield return new WaitForSeconds(randomDelay);

            // Activa la animación del logo
            logoAnimator.Play("LogoAnim");

            yield return new WaitForSeconds(3f); // Tiempo que dura la animación antes de reiniciar el ciclo; 
        }
        
    }
}
