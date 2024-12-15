using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evento_10 : MonoBehaviour
{
    public GameObject shadowPrefab;
    public GameObject shadowKitchenRunnerPrefab;
    public GameObject shadowMirror;
    public GameObject pos1;
    public GameObject pos2;
    public GameObject pos3;
    public GameObject pos4;
    public GameObject pos5;
    public GameObject pos6;
    public GameObject pos9;

    public void ShadowEvent1()
    {
        
       
            GameObject shadowEvent1 = Instantiate(shadowKitchenRunnerPrefab, pos1.transform.position, pos1.transform.rotation);
            ChangeAnimationInstancedOBJ(shadowEvent1, "RunningInstant");

    }

    public void ShadowEvent2()
    {
        
        
            GameObject shadowEvent2 = Instantiate(shadowPrefab, pos2.transform.position, pos2.transform.rotation);
            // Acceder al Animator del objeto instanciado.
            ChangeAnimationInstancedOBJ(shadowEvent2, "StandingNextToSofa");
    }

    public void ShadowEvent3()
    {
       
        
            GameObject shadowEvent3 = Instantiate(shadowPrefab, pos3.transform.position, pos3.transform.rotation);
            ChangeAnimationInstancedOBJ(shadowEvent3, "LightOff");
        
    }
    public void ShadowEvent4()
    {


        GameObject shadowEvent4 = Instantiate(shadowMirror, pos4.transform.position, pos4.transform.rotation);
        // La sombra del evento 10 que se activa en el evento 4, instancia la sombra cuando apaga la llave
        // Asegurarte de asignar la capa "pp" al objeto instanciado
        int mirrorLayer = LayerMask.NameToLayer("MirrorReflection"); // Obtener el �ndice de la capa "pp"
        if (mirrorLayer != -1) // Verificar que la capa exista
        {
            SetLayerRecursively(shadowEvent4, mirrorLayer);
        }
        else
        {
            Debug.LogWarning("La capa 'MirrorReflection' no existe. Aseg�rate de que est� definida en Unity.");
        }
        ChangeAnimationInstancedOBJ(shadowEvent4,"MirrorPose");
    }
    public void ShadowEvent5()
    {
        
        
            GameObject shadowEvent5 = Instantiate(shadowKitchenRunnerPrefab, pos5.transform.position, pos5.transform.rotation);
    }

    public void ShadowEvent6()
    {
        
        
            GameObject shadowEvent6 = Instantiate(shadowPrefab, pos6.transform.position, pos6.transform.rotation);
            ChangeAnimationInstancedOBJ(shadowEvent6, "BackYardPose");
    }
 

    public void ShadowEvent9()
    {
        
        
            GameObject shadowEvent9 = Instantiate(shadowPrefab, pos9.transform.position, pos9.transform.rotation);
            ChangeAnimationInstancedOBJ(shadowEvent9, "PuertaDeEntradaPose");
    }

    void SetLayerRecursively(GameObject obj, int newLayer)
    {
        if (obj == null) return;

        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            if (child == null) continue;
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }
    void ChangeAnimationInstancedOBJ(GameObject instanced, string animName)
    {
        Animator animator = instanced.GetComponentInChildren<Animator>();

            if(animator != null)
            {
                animator.Play(animName);
            }
    }
}
