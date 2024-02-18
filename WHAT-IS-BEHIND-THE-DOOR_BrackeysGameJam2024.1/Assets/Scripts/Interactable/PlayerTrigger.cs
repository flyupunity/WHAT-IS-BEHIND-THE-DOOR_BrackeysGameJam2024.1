using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public Animator doorAnim = null;

    public Animator leftDoorAnim = null;
    public Animator rightDoorAnim = null;
    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if (obj.tag == "Player")
        {
            if (doorAnim != null) doorAnim.SetTrigger("close");
            if (rightDoorAnim != null) leftDoorAnim.SetTrigger("close");
            if (rightDoorAnim != null) rightDoorAnim.SetTrigger("close");
        }
    }
}
