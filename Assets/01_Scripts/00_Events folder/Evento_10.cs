using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evento_10 : MonoBehaviour
{
    public GameObject shadow;
    public GameObject shadowRunner;
    public GameObject pos1;
    public GameObject pos2;
    public GameObject pos3;
    public GameObject pos4;
    public GameObject pos5;
    public GameObject pos6;
    public GameObject pos9;

    public void ShadowEvent1()
    {
        
       
            Instantiate(shadowRunner, pos1.transform.position, pos1.transform.rotation);
        
    }

    public void ShadowEvent2()
    {
        
        
            Instantiate(shadow, pos2.transform.position, pos2.transform.rotation);
        
    }

    public void ShadowEvent3()
    {
       
        
            Instantiate(shadow, pos3.transform.position, pos3.transform.rotation);
        
    }

    public void ShadowEvent4()
    {
        
        
            Instantiate(shadow, pos4.transform.position, pos4.transform.rotation);
        
    }
    public void ShadowEvent5()
    {
        
        
            Instantiate(shadowRunner, pos5.transform.position, pos5.transform.rotation);
        
    }

    public void ShadowEvent6()
    {
        
        
            Instantiate(shadow, pos6.transform.position, pos6.transform.rotation);
        
    }
 

    public void ShadowEvent9()
    {
        
        
            Instantiate(shadow, pos9.transform.position, pos9.transform.rotation);
        
    }


}
