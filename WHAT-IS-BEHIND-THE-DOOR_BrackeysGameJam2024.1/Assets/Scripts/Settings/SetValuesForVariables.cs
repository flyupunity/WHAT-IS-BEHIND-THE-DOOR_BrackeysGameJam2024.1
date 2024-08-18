using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetValuesForVariables : MonoBehaviour
{
    public AudioClip closedDoorClip = null;
    public GameObject LoadingScreenPrefab = null;

    public static SetValuesForVariables Instance;

    void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
