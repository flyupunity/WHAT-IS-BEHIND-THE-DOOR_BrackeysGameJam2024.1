using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Screamer : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    private void Update()
    {
        StartCoroutine(ScrimerCorutine());
    }
    public IEnumerator ScrimerCorutine()
    {
        GetComponent<AudioSource>().clip = clip;
        yield return new WaitForSecondsRealtime(5);
        Destroy(this.gameObject);
    }
}
