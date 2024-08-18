using System;
using System.Collections;
using System.Collections.Generic;
/*using UnityEngine.Audio;

/*[System.Serializable]
public struct randomazer
{
    public AudioClip clip;
    public float time;
    public float minSeparation;
    public float maxSeparation;
}
public class AudioRandomazer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource = null;
    [SerializeField] private randomazer[] randomazer = null;
    private void Start()
    {
        for (int i = 0; i < randomazer.Length; i ++)
        {
            randomazer[i].time = UnityEngine.Random.Range(randomazer[i].minSeparation, randomazer[i].maxSeparation);
            StartCoroutine(timerPlay(randomazer[i].time, randomazer[i].clip, i));
        }
    }
    IEnumerator timerPlay(float time, AudioClip clip, int i)
    {
        yield return new WaitForSeconds(time);
        audioSource.clip = clip;
        audioSource.Play();

        randomazer[i].time = UnityEngine.Random.Range(randomazer[i].minSeparation, randomazer[i].maxSeparation);
        StartCoroutine(timerPlay(randomazer[i].time, randomazer[i].clip, i));
    }
    private void OnValidate()
    {
        if (audioSource == null && GetComponent<AudioSource>() != null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }
}*/

