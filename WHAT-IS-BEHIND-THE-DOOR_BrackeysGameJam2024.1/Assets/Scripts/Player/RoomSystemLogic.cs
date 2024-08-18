using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSystemLogic : MonoBehaviour
{
    [Header("Input Keys")][Space(5)]
    [SerializeField] private LayerMask LayerMask;

    #region InputKey
    [Header("Input Keys")][Space(5)]
    [SerializeField] private KeyCode DrawRays;
    #endregion

    [Space(10)]

    [Header("Indices")][Space(5)]
    [SerializeField] private int index = 0;
    [SerializeField] private int indexActiveRoom = 0;

    [SerializeField] private GameObject[] room;

    private Ray ray;
    [SerializeField] private float rayLenght = 5f;
    void Start()
    {
        
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetKeyDown(DrawRays) && Physics.Raycast(ray, out hit, rayLenght, LayerMask, QueryTriggerInteraction.Collide/*Ignore*/))
        {
            GameObject hitObj = hit.collider.gameObject;
            if (hitObj.GetComponent<MetalDoor>()) {
                hitObj.GetComponent<MetalDoor>().MoveToClosingPoint(this.transform);
            }
        }
    }
}
