using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuandoSeAbraLaPuertaDeLaCocinaLaSombraPerseguiraAlJugadorScript : MonoBehaviour
{
    private string targetObjectName = "ShadowRunner(Clone)";
    public EventManager eventManager;
    
    public DoorScript doorScript;

    // Update is called once per frame
    void Update()
    {
        if (eventManager.currentEvent == EventManager.EventsToTrigger.Event1 && doorScript.isDoorOpen)
        {
            StartCoroutine(TriggerFollowAfterDelay());
        }
    }

    private IEnumerator TriggerFollowAfterDelay()
    {
        // Espera 1 segundo
        yield return new WaitForSeconds(0.5f);

        // Busca el objeto por su nombre
        GameObject targetObject = GameObject.Find(targetObjectName);

        if (targetObject != null)
        {
            // Extrae el componente del objeto encontrado
            EnemyRunBehiavor component = targetObject.GetComponent<EnemyRunBehiavor>();

            if (component != null)
            {
                // Cambia una variable del componente
                component.isFollowing = true;
            }
        }
    }
}
