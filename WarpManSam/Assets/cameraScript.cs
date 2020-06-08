using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    Camera cam;
    public float baseSize = 5.386971f;

    public void Start()
    {
        cam = GetComponent<Camera>();
        cam.orthographicSize = baseSize;
    }

    public void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && cam.orthographicSize >= 5f)
        {
            cam.orthographicSize -=  0.001f;
        } else
        {
            cam.orthographicSize = baseSize;
        }
    }
}
