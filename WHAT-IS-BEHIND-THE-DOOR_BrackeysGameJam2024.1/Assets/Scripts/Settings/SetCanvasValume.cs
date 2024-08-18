using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Canvas))]
public class SetCanvasValume : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    void Update()
    {
        if (canvas.renderMode == RenderMode.ScreenSpaceCamera)
        {
            canvas.worldCamera = GameObject.FindGameObjectWithTag("Camera for UI").GetComponent<Camera>();
        }
    }
    private void OnValidate()
    {
        canvas = GetComponent<Canvas>();
    }
}
