using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform playerCam;

    void LateUpdate()
    {
        Vector3 direction = playerCam.position - transform.position;

        // Opcional: Ignorar el eje Y (rotar solo en X-Z para evitar inclinaciones).
        direction.y = 0;

        transform.rotation = Quaternion.LookRotation(direction);
    }
    private void OnBecameVisible()
    {
        // Activar el script cuando el objeto esté dentro de la visión de la cámara.
        enabled = true;
    }

    private void OnBecameInvisible()
    {
        // Desactivar el script cuando el objeto esté fuera de la visión de la cámara.
        enabled = false;
    }
}
