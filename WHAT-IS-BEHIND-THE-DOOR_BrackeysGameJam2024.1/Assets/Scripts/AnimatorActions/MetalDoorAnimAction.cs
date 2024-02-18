using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MetalDoorAnimAction : MonoBehaviour
{
    [SerializeField] private AudioSource open;
    [SerializeField] private AudioSource close;
    public void PlayOpeningAudioSource()
    {
        open.Play();
    }
    public void PlayClosingAudioSource()
    {
        close.Play();
    }

}
