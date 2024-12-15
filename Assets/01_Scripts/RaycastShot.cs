using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShot : MonoBehaviour
{
    public Camera playerCamera;  // Referencia a la c�mara en primera persona
    public float rayDistance = 100f;  // Distancia del raycast
    public LayerMask enemyLayer;  // Capas que el raycast puede afectar (opcional)

    public AudioSource sombraAudio;

    private void Awake()
    {
        GameObject sombraObject = GameObject.Find("SombraAudio");

        if (sombraObject != null)
        {
            sombraAudio = sombraObject.GetComponent<AudioSource>();
        }
    }
    private void Update()
    {
        ShootRay();
    }
    void ShootRay()
    {
        // Crear el raycast desde el centro de la pantalla (c�mara)
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        // Si el raycast colisiona con algo
        if (Physics.Raycast(ray, out hit, rayDistance, enemyLayer))
        {
            // Verifica si el objeto colisionado es un enemigo (puedes comprobar por tag o script)
            if (hit.collider.CompareTag("ShadowEvent7"))  // Aseg�rate de que el enemigo tenga el tag "Enemy"
            {
                sombraAudio.Play();
                Transform currentTransform = hit.transform;

                // Recorre la jerarquía hacia arriba y destruye todos los padres
                while (currentTransform.parent != null)
                {
                    Transform parentTransform = currentTransform.parent; // Obtén el padre
                    parentTransform.gameObject.SetActive(false); // Destruye el objeto padre
                    Debug.Log("Padre destruido: " + parentTransform.name);
                    currentTransform = parentTransform; // Avanza al siguiente nivel
                }
            }
        }
        if (Physics.Raycast(ray, out hit, rayDistance, enemyLayer))
        {
            // Verifica si el objeto colisionado es un enemigo (puedes comprobar por tag o script)
            if (hit.collider.CompareTag("ShadowEvent10"))  // Aseg�rate de que el enemigo tenga el tag "Enemy"
            {
                sombraAudio.Play();
                Destroy(hit.transform.parent.gameObject);
            }
        }

        if (Physics.Raycast(ray, out hit, rayDistance, enemyLayer))
        {
            // Verifica si el objeto colisionado es un enemigo (puedes comprobar por tag o script)
            if (hit.collider.CompareTag("ShadowRunner"))  // Aseg�rate de que el enemigo tenga el tag "Enemy"
            {
                EnemyRunBehiavor enemyScript = hit.collider.GetComponent<EnemyRunBehiavor>();

                if (enemyScript != null)
                {
                    // Activa la variable isFollowing en el script del enemigo
                    enemyScript.isFollowing = true;  // Activa directamente la variable
                }


            }
        }
    }
}
