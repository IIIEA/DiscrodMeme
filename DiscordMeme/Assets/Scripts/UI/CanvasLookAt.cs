using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLookAt : MonoBehaviour
{
    [SerializeField] private Transform _canvasTransform;

    private void LateUpdate()
    {
        _canvasTransform.LookAt(Camera.main.transform);
    }
}
