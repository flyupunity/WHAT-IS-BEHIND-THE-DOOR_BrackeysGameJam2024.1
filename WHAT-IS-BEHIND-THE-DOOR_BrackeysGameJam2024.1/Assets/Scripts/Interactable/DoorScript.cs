using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum DoorTypes
{
    [InspectorName("Door in house")] house,
    [InspectorName("Door in basement")] basement,
}
public class DoorScript : MonoBehaviour
{
    [SerializeField] private DoorTypes type = DoorTypes.house;
    public void OpenTheDoor()
    {
        if (type == DoorTypes.house)
        {  
            GetComponentInParent<Animator>().enabled = true;
            GetComponentInParent<AudioSource>().Play();
        }
        else if (type == DoorTypes.basement)
        {
            GetComponent<Animator>().enabled = true;
            GetComponent<AudioSource>().Play();
        }
    }
}
