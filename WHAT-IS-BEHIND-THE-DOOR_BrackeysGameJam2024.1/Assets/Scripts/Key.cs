using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    //	public string Tag;

    public Sprite Sprite;
    public bool piano = false;

    public bool Tools = false;
    public bool Delete = false;

    public bool CapCap = false;

    public bool LatestLevel = false;
    public int index;

    public void OnMouseDown()
    {
        if (piano || Delete)
        {
            GetComponent<Animator>().SetBool("Click", true);
            GetComponentInChildren<AudioSource>().Play();
        }
    }
    void OffAnimator()
    {
        GetComponent<Animator>().SetBool("Click", false);
    }
    void OnAudio(AudioSource audioSource2)
    {
        //audioSource2.Play();
    }
    void OnCollisionEnter(Collision col)
    {
        if (CapCap)
        {
            //transform.GetChild(0).GetComponent<AudioSource>().Play();
            transform.localPosition = new Vector3(0.00335f, -0.0127f, -0.01837f);
        }
    }
    /*void OnCollisionEnter(Collision col)
    {
        if(LatestLevel && col.collider.gameObject.GetComponent<Key>() && col.collider.gameObject.GetComponent<Key>().Tools)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<MyPlayerScript>().Tools[];
        }
    }*/
}
