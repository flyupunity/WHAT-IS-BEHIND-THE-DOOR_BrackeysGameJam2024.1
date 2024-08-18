using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Screamer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource = null;
    [SerializeField] private AudioClip[] audioClips = null;
    private bool corutineStarted = false;

    public IEnumerator PlayRamdomScrimerSoundCorutine()
    {
        corutineStarted = true;
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
        yield return new WaitForSecondsRealtime(audioSource.clip.length);
        Destroy(this.gameObject);
    }
    private void Update()
    {
        if(!corutineStarted) StartCoroutine(PlayRamdomScrimerSoundCorutine());
    }
    private void OnValidate()
    {
        if (audioSource == null && GetComponent<AudioSource>() != null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }
}

