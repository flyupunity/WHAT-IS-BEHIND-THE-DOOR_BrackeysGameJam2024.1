using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Audio;

public class Progress : MonoBehaviour
{
    public bool isNight = false;
    public bool dontMove = false;

    public AudioClip closedDoorClip = null;
    public static Progress Instance;
    void Awake()
    {
        if(Instance == null){    
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }else{
            Destroy(gameObject);
        }
    }
    void Start()
    {
        isNight = false;
    }
    private void Update() {
        
    }
}
