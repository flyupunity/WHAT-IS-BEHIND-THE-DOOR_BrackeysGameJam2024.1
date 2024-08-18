using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MetalDoor : MonoBehaviour
{
    [SerializeField] private Transform _closingPoint = null;
    [SerializeField] private AudioSource audioSource;
    public void MoveToClosingPoint(Transform _objTransform)
    {
        _objTransform.position = _closingPoint.position;
    }

}
