using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementDoorAnimActions : MonoBehaviour
{
    public void AnimatorActiveIsFalse()
    {
        GetComponent<Animator>().enabled = false;
    }
}
