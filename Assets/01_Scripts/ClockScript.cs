using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClockScript : MonoBehaviour
{
    public TextMeshProUGUI clockText;
    public bool frezzeTime = false;

    public float timeInMinutes = 600; // Empieza en 8:00 AM (8 * 60)
    public float timeScale = 1f; // Escala del tiempo, ajusta para cambiar la velocidad.

    void Update()
    {
        if (!frezzeTime) // Avanza el tiempo en base a la escala deseada
        {
            timeInMinutes += Time.deltaTime * timeScale;
        }
            
        

        // Si el tiempo llega a 1440 minutos (24 horas), resetea a 0
        if (timeInMinutes >= 1440)
        {
            timeInMinutes = 0;
        }

        // Calcula la hora y minuto actual
        int hours = Mathf.FloorToInt(timeInMinutes / 60);
        int minutes = Mathf.FloorToInt(timeInMinutes % 60);

        // Determina si es AM o PM
        string period = hours >= 12 ? "PM" : "AM";

        // Convierte a formato de 12 horas
        hours = hours % 12;
        if (hours == 0) hours = 12; // Asegura que 00:00 sea 12:00 AM

        // Actualiza el texto del reloj en formato "HH:MM AM/PM"
        clockText.text = string.Format("{0:00}:{1:00} {2}", hours, minutes, period);
    }
}
