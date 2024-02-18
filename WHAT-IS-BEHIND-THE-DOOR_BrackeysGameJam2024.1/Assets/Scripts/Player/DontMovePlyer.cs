using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontMovePlyer : MonoBehaviour
{
    private MyPlayerScript script1;
    private FirstPersonController script2;
    void Start()
    {
        script1 = GetComponent<MyPlayerScript>();
        script2 = GetComponent<FirstPersonController>();
    }
    void Update()
    {
        if (Progress.Instance.dontMove)
        {
            script1.enabled = false;
            script2.cameraCanMove = false;

            script2.playerCanMove = false;
            script2.enabled = false;
        }
        if (!Progress.Instance.dontMove)
        {
            script1.enabled = true;
            script2.cameraCanMove = true;

            script2.playerCanMove = true;
            script2.enabled = true;
        }
    }
}
