using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class MenuPausaScript : MonoBehaviour
{
    public AudioMixer audioMixer;
    private float originalVolume;
    public GameObject panelMenu;
    public bool isPausa;
    public MonoBehaviour cameraScript;
    public ComputerInteraction computerInteraction;
    public bool AhoraPuedesLlamarAlMenu = true;

    void Start()
    {
        CerrarMenu();
        JuegoReanulado();
    }

    
    public void CerrarMenu()
    {
        JuegoReanulado();
        panelMenu.SetActive(false);
        ResumeAudio();
       
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPausa)
            {
                //CerrarMenu();
                
            }
            else
            {
                if (computerInteraction.isInInteraction == false && AhoraPuedesLlamarAlMenu == true || AhoraPuedesLlamarAlMenu == true) 
                {
                    AbrirMenu(); 
                }
                    
            }
        }
    }

    public void AbrirMenu()
    {
        panelMenu.SetActive(true);
        JuegoPausado();
        PauseAudio();
    } 

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void SalirAlMenuPrincipal()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }

    public void JuegoPausado()
    {
        
        isPausa = true;

        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;

        
        if (cameraScript != null)
        {
            cameraScript.enabled = false;
        }
        Time.timeScale = 0f;
    }

    void JuegoReanulado()
    {
        Time.timeScale = 1f; 
        isPausa = false;

        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;

        
        if (cameraScript != null)
        {
            cameraScript.enabled = true;
        }
    }

    public void PauseAudio()
    {
        
        audioMixer.GetFloat("MasterVolume", out originalVolume);
        
        audioMixer.SetFloat("MasterVolume", -80f);
    }

    public void ResumeAudio()
    {
      
        audioMixer.SetFloat("MasterVolume", originalVolume);
    }
}
