using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LampAudioSounds : MonoBehaviour
{
    [Header("Play time")][Space(10)]
    [SerializeField] private float minPlayTime = 1f;
    [SerializeField] private float maxPlayTime = 10f;

    [Space(15)]

    [Header("Flashing")][Space(10)]
    [SerializeField] private float minFlashingTime = 0.1f;
    [SerializeField] private float maxFlashingTime = 0.3f;

    [Space(5)]

    [SerializeField] private int maxNumberLampFlashes = 3;
    [SerializeField] private Light light = null;

    [Space(15)]

    [Header("Audio")][Space(10)]
    [SerializeField] private PlayRamdomSound ramdomSoundScript = null;

    public void Start()
    {
        StartCoroutine(TimerPlay());
    }
    IEnumerator TimerPlay()
    {
        float time = UnityEngine.Random.Range(minPlayTime, maxPlayTime);
        yield return new WaitForSeconds(time);

        int numberLampFlashes = UnityEngine.Random.Range(1, maxNumberLampFlashes);
        ramdomSoundScript.PlayRamdomSoundFromList();
        for (int i = 0; i <= numberLampFlashes; i++)
        {
            yield return StartCoroutine(TimeFlashing());
        }
        StartCoroutine(TimerPlay());
    }
    IEnumerator TimeFlashing()
    {
        light.enabled = false;
        float time = UnityEngine.Random.Range(minFlashingTime, maxFlashingTime);
        yield return new WaitForSeconds(time);
        light.enabled = true;
        ramdomSoundScript.PlayRamdomSoundFromList();
        yield return new WaitForSeconds(0.1f);
    }
    private void OnValidate()
    {
        if (ramdomSoundScript == null && GetComponent<PlayRamdomSound>() != null)
        {
            ramdomSoundScript = GetComponent<PlayRamdomSound>();
        }
        if (light == null && GetComponent<Light>() != null)
        {
            light = GetComponent<Light>();
        }
    }
}

