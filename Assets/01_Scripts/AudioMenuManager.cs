using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMenuManager : MonoBehaviour
{
    public AudioSource clickAudio;
   
    // Start is called before the first frame update
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickAudio.Play();
        }
    }
}
