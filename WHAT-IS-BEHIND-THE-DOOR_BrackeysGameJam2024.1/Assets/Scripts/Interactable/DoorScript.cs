using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum DoorTypes
{
    [InspectorName("Door in house")] house,
    [InspectorName("Door in basement")] basement,
    [InspectorName("Wait a night")] night,
    [InspectorName("Turn off")] off,
}
public class DoorScript : MonoBehaviour
{
    [SerializeField] private bool closing = true;
    public DoorTypes type = DoorTypes.house;
    private void Start()
    {
        if (type == DoorTypes.basement) type = DoorTypes.night;
    }
    private void Update()
    {
        if (type != DoorTypes.off && Progress.Instance.isNight == true) {
            if (type == DoorTypes.night) type = DoorTypes.basement;
            if (type == DoorTypes.house && closing)
            {
                type = DoorTypes.off;
                //GetComponentInParent<Animator>().speed = -1;
                GetComponentInParent<Animator>().SetTrigger("night");
                GetComponentInParent<AudioSource>().clip = SetValuesForVariables.Instance.closedDoorClip;
            }
        }
    }
    public void OpenTheDoor()
    {
        if (type == DoorTypes.house)
        {  
            GetComponentInParent<Animator>().enabled = true;
            GetComponentInParent<AudioSource>().Play();
            GetComponent<Key>().hoverText = "";
        }
        else if (type == DoorTypes.basement)
        {
            GetComponent<Animator>().enabled = true;
            if(GetComponent<AudioSource>() != null) GetComponent<AudioSource>().Play();
            GetComponent<Key>().hoverText = "";
        }
        if (type == DoorTypes.off) GetComponent<AudioSource>().Play();
    }
    public void CloseTheBasementDoor()
    {

    }
}
