using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evento_10 : MonoBehaviour
{
    public GameObject shadowPrefab;
    public GameObject shadowKitchenRunnerPrefab;
    public GameObject pos1;
    public GameObject pos2;
    public GameObject pos3;
    public GameObject pos4;
    public GameObject pos5;
    public GameObject pos6;
    public GameObject pos9;

    public void ShadowEvent1()
    {
        
       
            Instantiate(shadowKitchenRunnerPrefab, pos1.transform.position, pos1.transform.rotation);
        
    }

    public void ShadowEvent2()
    {
        
        
            Instantiate(shadowPrefab, pos2.transform.position, pos2.transform.rotation);
        
    }

    public void ShadowEvent3()
    {
       
        
            Instantiate(shadowPrefab, pos3.transform.position, pos3.transform.rotation);
        
    }

    public void ShadowEvent4()
    {
        
        
            Instantiate(shadowPrefab, pos4.transform.position, pos4.transform.rotation);
        
    }
    public void ShadowEvent5()
    {
        
        
            Instantiate(shadowKitchenRunnerPrefab, pos5.transform.position, pos5.transform.rotation);
        
    }

    public void ShadowEvent6()
    {
        
        
            Instantiate(shadowPrefab, pos6.transform.position, pos6.transform.rotation);
        
    }
 

    public void ShadowEvent9()
    {
        
        
            Instantiate(shadowPrefab, pos9.transform.position, pos9.transform.rotation);
        
    }


}
