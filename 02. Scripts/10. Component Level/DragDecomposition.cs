using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDecomposition : MonoBehaviour
{
    private float CameraZDistance;

    void Start()
    {
        CameraZDistance = Camera.main.WorldToScreenPoint(transform.position).z;
    }
    private void Update()
    {


    }

    void OnMouseDrag()
    {
            Vector3 ScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, CameraZDistance);
            Vector3 NewWorldPosition = Camera.main.ScreenToWorldPoint(ScreenPosition);
            transform.position = NewWorldPosition;
    }

    // https://www.youtube.com/watch?v=0yHBDZHLRbQ

}