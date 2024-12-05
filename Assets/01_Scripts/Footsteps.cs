using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource sfxSource;
    public AudioClip footsteps;
    public void PlayFootsteps()
    {       
            sfxSource.PlayOneShot(footsteps);
            sfxSource.pitch = Random.Range(0.8f, 1.2f);       
    }
}
