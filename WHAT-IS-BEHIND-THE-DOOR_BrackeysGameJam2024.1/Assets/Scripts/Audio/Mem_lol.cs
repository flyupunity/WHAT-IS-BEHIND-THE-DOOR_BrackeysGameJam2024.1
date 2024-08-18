using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Mem_lol : MonoBehaviour
{
    [SerializeField] private AudioClip mem;
    void Update()
    {
        if(PlayerPrefs.GetInt("Mem") == 1)
        {
            GetComponent<AudioSource>().clip = mem;
        }
    }
}
