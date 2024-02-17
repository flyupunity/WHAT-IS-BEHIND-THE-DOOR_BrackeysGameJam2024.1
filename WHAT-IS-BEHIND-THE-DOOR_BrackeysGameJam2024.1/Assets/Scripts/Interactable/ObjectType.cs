using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum ObjectTypes
{
    [InspectorName("None")] none,
    [InspectorName("Flashligth")] flashligth,
    [InspectorName("First door")] door1,
    [InspectorName("Second door")] soor2,
    [InspectorName("Screw")] screw,
    [InspectorName("Piano")] piano,
    [InspectorName("Piano key")] pianoKey,
    [InspectorName("Cabinet key")] cabinetKey,
    [InspectorName("Hammer")] hammer,
    [InspectorName("Wrench")] wrench,
    [InspectorName("Suitcase")] suitcase,
    [InspectorName("Impact wrench")] impactWrench,
    [InspectorName("Notes")] notes,
    [InspectorName("Win box")] winBox,
}
[System.Serializable]
public class ObjectType : MonoBehaviour
{
    public ObjectTypes type = ObjectTypes.none;
    void Start()
    {
        if (type == ObjectTypes.none) Debug.LogError($"The object '{gameObject.name}' is not given a type!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
