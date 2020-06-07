﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class playerMovement : MonoBehaviour
{
    public Vector3 target;
    public Vector3 previousPosition;
    public GameObject bullet;
    public GameObject rangeIndicator;

    Rigidbody2D rb;
    Vector2 movement;
    Vector2 mousePos;

    public timeManager timeManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = transform.position;
    }

    void Update()
    {
        rangeIndicator.SetActive(false);

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            timeManager.doSlowmotion();
            rangeIndicator.SetActive(true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Teleport();
        }
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    void Teleport()
    {
        previousPosition = gameObject.transform.position;

        target = mousePos;
        target.z = transform.position.z;
        transform.position = target;

        GameObject go = Instantiate(bullet, previousPosition, Quaternion.identity);
        go.transform.rotation = transform.rotation;

        timeManager.doSlowmotion();
    }
}