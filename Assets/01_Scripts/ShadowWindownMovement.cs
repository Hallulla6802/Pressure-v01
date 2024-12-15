using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowWindownMovement : MonoBehaviour
{
    public Vector3 direction; // Direcci�n a la que se mover� el enemigo
    public float speed = 5f;  // Velocidad de movimiento

    public  void Start()
    {
        StartCoroutine(DestroyAfterTime(3f)); // 10 segundos
    }

    void Update()
    {
        // Mover el enemigo en la direcci�n asignada
        transform.position += direction * speed * Time.deltaTime;
    }

    private IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject); // Destruir el enemigo despu�s de que pase el tiempo
    }
}
