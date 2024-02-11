using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioRandomazer : MonoBehaviour
{
    [SerializeField] private randomazer[] randomazer;
    private void Start()
    {
        for (int i = 0; i < randomazer.Length; i ++)
        {
            randomazer[i].time = UnityEngine.Random.Range(randomazer[i].minSeparation, randomazer[i].maxSeparation);
            StartCoroutine(timerPlay(randomazer[i].time, randomazer[i].audio, i));
        }
    }
    IEnumerator timerPlay(float time, AudioSource audio, int i)
    {
        yield return new WaitForSeconds(time);
        audio.Play();

        randomazer[i].time = UnityEngine.Random.Range(randomazer[i].minSeparation, randomazer[i].maxSeparation);
        StartCoroutine(timerPlay(randomazer[i].time, randomazer[i].audio, i));
    }
}
[Serializable]
public struct randomazer
{
    public AudioSource audio;
    public float time;
    public float minSeparation;
    public float maxSeparation;
}
