using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Sprite Sprite;
    public string hoverText = "take";

    public string descriptiveText = "it's an object, isn't it?";
    public bool dontTouch = false;
    public int index;

    void OnCollisionEnter(Collision col)
    {

    }
}
