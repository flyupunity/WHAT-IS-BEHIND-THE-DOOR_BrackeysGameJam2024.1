using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayRamdomSound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource = null;
    [SerializeField] private AudioClip[] audioClips = null;
    public void PlayRamdomSoundFromList()
    {
        if (audioClips != null && audioSource != null) 
        {
            int randomValue = Random.Range(0, audioClips.Length);
            audioSource.clip = audioClips[randomValue];
            audioSource.Play();
        }
        else
        {
            if (audioSource == null) Debug.LogError($"Audio Source Component in '{gameObject.name}' is null !!!");
            if (audioClips == null) Debug.LogError($"Audio Clips values in '{gameObject.name}' is empty !!!");
        }
    }
    private void OnValidate()
    {
        if (audioSource == null && GetComponent<AudioSource>() != null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }
}
