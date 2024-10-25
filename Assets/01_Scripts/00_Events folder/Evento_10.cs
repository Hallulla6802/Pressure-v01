using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evento_10 : MonoBehaviour
{
    public GameObject shadow;
    public GameObject pos1;
    public GameObject pos2;
    public GameObject pos3;
    public GameObject pos4;
    public GameObject pos5;
    public GameObject pos6;
    public GameObject pos9;

    public void ShadowEvent1()
    {
        if (Random.Range(0f, 1f) <= 0.5f)
        {
            Instantiate(shadow, pos1.transform.position, pos1.transform.rotation);
        }
    }

    public void ShadowEvent2()
    {
        if (Random.Range(0f, 1f) <= 0.5f)
        {
            Instantiate(shadow, pos2.transform.position, pos2.transform.rotation);
        }
    }

    public void ShadowEvent3()
    {
        if (Random.Range(0f, 1f) <= 0.5f)
        {
            Instantiate(shadow, pos3.transform.position, pos3.transform.rotation);
        }
    }

    public void ShadowEvent4()
    {
        if (Random.Range(0f, 1f) <= 0.5f)
        {
            Instantiate(shadow, pos4.transform.position, pos4.transform.rotation);
        }
    }
    public void ShadowEvent5()
    {
        if (Random.Range(0f, 1f) <= 0.5f)
        {
            Instantiate(shadow, pos5.transform.position, pos5.transform.rotation);
        }
    }

    public void ShadowEvent6()
    {
        if (Random.Range(0f, 1f) <= 0.5f)
        {
            Instantiate(shadow, pos6.transform.position, pos6.transform.rotation);
        }
    }
 

    public void ShadowEvent9()
    {
        if (Random.Range(0f, 1f) <= 0.5f)
        {
            Instantiate(shadow, pos9.transform.position, pos9.transform.rotation);
        }
    }


}
