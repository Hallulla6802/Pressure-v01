using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManagerRedux : MonoBehaviour
{
    #region VARIABLES

    [Header("MIXER")]
    [Space]

    [SerializeField] private AudioMixer mainMixer;

    [Header("SLIDERS")]
    [Space]

    [SerializeField] private Slider generalSlider;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;

    #endregion

    private void Start()
    {        
        LoadValues();
    }


    #region VOLUME SETTINGS

    #region General Volume

    public void SetGeneralVolume(float sliderValue)
    {
        mainMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
    }

    #endregion

    #region BG Volume
    public void SetMusicVolume(float sliderValue)
    {
        mainMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
    }
        #endregion

        #region SFX Volume

    public void SetSFXVolume(float sliderValue)
    {
        mainMixer.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20);
    }


    #endregion

    #endregion

    #region SAVE & LOAD VOLUME

    public void SaveVolumeButton()
    {
        
        PlayerPrefs.SetFloat("MasterValue", generalSlider.value);       
        PlayerPrefs.SetFloat("MusicValue", musicVolumeSlider.value);
        PlayerPrefs.SetFloat("SFXValue", sfxVolumeSlider.value);    

        PlayerPrefs.Save(); 
    }
    void LoadValues()
    {         
        mainMixer.SetFloat("MasterVolume", Mathf.Log10(PlayerPrefs.GetFloat("MasterValue", 1) * 20));             
        mainMixer.SetFloat("MusicVolume", Mathf.Log10(PlayerPrefs.GetFloat("MusicValue", 1) * 20));      
        mainMixer.SetFloat("SFXVolume", Mathf.Log10(PlayerPrefs.GetFloat("SFXValue", 1) * 20));  
        generalSlider.value = PlayerPrefs.GetFloat("MasterValue", 1); 
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicValue", 1);    
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXValue", 1);
    }
    #endregion
}
