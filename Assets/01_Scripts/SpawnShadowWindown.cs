using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShadowWindown : MonoBehaviour
{
    public GameObject enemyShadowPrefab; // Prefab del enemigo sombra
    public Transform spawnLeft;          // Transform del spawn izquierdo
    public Transform spawnRight;         // Transform del spawn derecho
    public float spawnProbability = 0f;  // Probabilidad de spawn inicial
    public float increaseProbability = 20f; // Aumento de probabilidad en cada intento fallido

    private Transform selectedSpawn;     // Spawn elegido al azar

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Si el player entra en el trigger
        {
            // Generar un número aleatorio entre 0 y 100
            float randomValue = Random.Range(0f, 100f);

            // Chequear si la probabilidad es suficiente para hacer spawn del enemigo
            if (randomValue < spawnProbability)
            {
                SpawnEnemy(); // Si la probabilidad es suficiente, spawneamos el enemigo
                spawnProbability = 0f; // Reiniciar la probabilidad a 0
            }
            else
            {
                // Aumentar la probabilidad para la próxima vez
                spawnProbability += increaseProbability;
            }
        }
    }

    private void SpawnEnemy()
    {
        // Elegir un spawn al azar (izquierda o derecha)
        selectedSpawn = Random.Range(0, 2) == 0 ? spawnLeft : spawnRight;

        // Crear el enemigo en la posición del spawn elegido
        GameObject enemy = Instantiate(enemyShadowPrefab, selectedSpawn.position, Quaternion.identity);

        // Asignar la dirección de movimiento del enemigo
        ShadowWindownMovement shadowWindownMovent = enemy.GetComponent<ShadowWindownMovement>();

        if (selectedSpawn == spawnLeft)
        {
            shadowWindownMovent.direction = Vector3.left; // Hacia -X
        }
        else
        {
            shadowWindownMovent.direction = Vector3.right; // Hacia +X
        }
    }
}
