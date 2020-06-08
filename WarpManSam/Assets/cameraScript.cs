using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    Camera cam;
    private float screenshakeIntensity;
    private Vector3 initialPosition;

    public void Start()
    {
        cam = GetComponent<Camera>();

        screenshakeIntensity = 0f;
        initialPosition = transform.localPosition;
    }

    public void FixedUpdate()
    {
        transform.localPosition = initialPosition + Random.insideUnitSphere * screenshakeIntensity;

        if (Input.GetMouseButton(0))
        {
            screenshakeIntensity += 0.0005f;
        } else
        {
            screenshakeIntensity = 0f;
        }
    }
}
