using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using Unity.VisualScripting;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;
    //public AudioMixer audioMixer1;

    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private Slider pitchSlider = null;

    [SerializeField] private Toggle audioToggle = null;
    [SerializeField] private Toggle postProcessingToggle = null; 

    private GameObject[] postProcessingObjs = null;

    private void Start() {
        postProcessingObjs = GameObject.FindGameObjectsWithTag("PostProcessing");
        if(PlayerPrefs.GetFloat("volume") != 0) {
            volumeSlider.value = PlayerPrefs.GetFloat("volume");
            audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("volume"));
        }
        if(PlayerPrefs.GetFloat("pitch") != 0){
            pitchSlider.value = PlayerPrefs.GetFloat("pitch");
            audioMixer.SetFloat("pitch", PlayerPrefs.GetFloat("pitch"));
        }
        if(PlayerPrefs.GetInt("audioToggle") == 1) audioToggle.isOn = false;
        if(PlayerPrefs.GetInt("audioToggle") == 2) audioToggle.isOn = true;
        if(PlayerPrefs.GetInt("postProcessingToggle") == 1){
            SetPostProcessing(false);
            postProcessingToggle.isOn = false;
        }else if(PlayerPrefs.GetInt("postProcessingToggle") == 2) {
            SetPostProcessing(true);
            postProcessingToggle.isOn = true;
        }
    }
    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("volume", volume);
        audioMixer.SetFloat("volume", volume);
        //audioMixer1.SetFloat("volume", volume + 20f);
    }
    public void SetPitch(float pitch)
    {
        PlayerPrefs.SetFloat("pitch", pitch);
        audioMixer.SetFloat("pitch", pitch);
    }
    public void SetAudioPause(bool value){
        if(value){
            volumeSlider.value = PlayerPrefs.GetFloat("volume");
            audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("volume"));
            PlayerPrefs.SetInt("audioToggle", 2);
        }else{
            //volumeSlider.value = -80f;
            audioMixer.SetFloat("volume", -80f);
            PlayerPrefs.SetInt("audioToggle", 1);
        }
        //AudioListener.pause = !(value);
    }
    public void SetPostProcessing(bool value){
        for (int i = 0; i < postProcessingObjs.Length; i++){
            postProcessingObjs[i].SetActive(value);
        }
        PlayerPrefs.SetInt("postProcessingToggle", value==false?1:2);
    }
    public void ResetSettings()
    {
        audioToggle.isOn = true;
        volumeSlider.value = 0;
        volumeSlider.interactable = true;
        audioMixer.SetFloat("volume", 0);

        SetPostProcessing(true);

        pitchSlider.value = 1;
        audioMixer.SetFloat("pitch", 1);
    }
    /*public void SetPitch(float pitch)
    {
        audioMixer.SetFloat("pitch", pitch);
        audioMixer1.SetFloat("pitch", pitch);
    }*/
}
