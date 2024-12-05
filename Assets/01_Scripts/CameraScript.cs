using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float mouseSensitivity = 2f;
    public Transform playerBody;  // Referencia al cuerpo del jugador
    public bool canLook = true;
    private float xRotation = 0f;
    public Transform arm;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  // Bloquear el cursor en la pantalla
        xRotation = 0f;  // La cámara comenzará mirando hacia adelante
    }

    void Update()
    {
        if(canLook)
        {
            // Movimiento del ratón
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            // Rotación del cuerpo del jugador en el eje Y (horizontal)
            playerBody.Rotate(Vector3.up * mouseX);

            // Rotación de la cámara en el eje X (vertical), con un límite
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // Limitar la rotación vertical para no girar demasiado

            
            // Aplicar la rotación a la cámara
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }
        
    }
}
