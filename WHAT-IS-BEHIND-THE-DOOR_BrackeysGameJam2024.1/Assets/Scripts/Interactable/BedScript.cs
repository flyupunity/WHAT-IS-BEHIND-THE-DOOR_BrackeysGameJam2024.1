using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class BedScript : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject sourse;
    [SerializeField] private bool nightStarted;

    [SerializeField] private Camera m_Camera;
    [SerializeField] private Camera b_Camera;

    private Animator anim;
    private void Start()
    {
        m_Camera = Camera.main;
        nightStarted = false;
        anim = GetComponent<Animator>();
    }
    public void GoToBed()
    {
        anim.enabled = true;
        nightStarted = true;
        Progress.Instance.dontMove = true;
        ChangeCamera(m_Camera, b_Camera);
    }
    private void Update()
    {
        if(nightStarted && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("WakeUp");
            nightStarted = false;

        }
    }
    public void NightStarting()
    {
        Progress.Instance.isNight = true;
        StartCoroutine(sourseCorutine());

        text.SetActive(true);
    }
    public void WakeUp()
    {
        Progress.Instance.dontMove = false;
        ChangeCamera(b_Camera, m_Camera);
        Destroy(this);
    }

    public void ChangeCamera(Camera fromCamera, Camera toCamera)
    {
        fromCamera.gameObject.SetActive(false);
        toCamera.gameObject.SetActive(true);
    }
    public IEnumerator sourseCorutine()
    {
        sourse.SetActive(true);
        yield return new WaitForSecondsRealtime(5);
        Destroy(sourse);
    }
}
