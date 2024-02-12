using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MyPlayerScript))]
public class MyPlayerScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        MyPlayerScript script = (MyPlayerScript)target;


        GUILayout.BeginHorizontal();
        if (GUILayout.Button("All active"))
        {
        }
        GUILayout.EndHorizontal();
    }
}
