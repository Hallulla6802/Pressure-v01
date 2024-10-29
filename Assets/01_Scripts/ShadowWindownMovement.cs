using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowWindownMovement : MonoBehaviour
{
    public Vector3 direction; // Dirección a la que se moverá el enemigo
    public float speed = 3f;  // Velocidad de movimiento

    public  void Start()
    {
        StartCoroutine(DestroyAfterTime(10f)); // 10 segundos
    }

    void Update()
    {
        // Mover el enemigo en la dirección asignada
        transform.position += direction * speed * Time.deltaTime;
    }

    private IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject); // Destruir el enemigo después de que pase el tiempo
    }
}
