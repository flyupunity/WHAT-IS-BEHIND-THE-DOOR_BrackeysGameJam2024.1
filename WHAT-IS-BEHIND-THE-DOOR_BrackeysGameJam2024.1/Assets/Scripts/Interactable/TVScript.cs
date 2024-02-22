using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVScript : MonoBehaviour
{
    [SerializeField] private GameObject goodbye = null;
    [SerializeField] private GameObject rickRoll = null;
    private void OnMouseDown()
    {
        goodbye.SetActive(false);
        rickRoll.SetActive(true);
    }
}
