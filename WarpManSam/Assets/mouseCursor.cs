using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseCursor : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    private Vector4 inactive;
    private Vector4 active;
    private Vector4 noTP;

    public LayerMask wallLayer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Cursor.visible = false;

        active = new Vector4(1f, 1f, 1f, 0.35f);
        noTP = new Vector4(1f, 0f, 0f, 0.35f);
        spriteRenderer.color = inactive;
    }

    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;

        if (Physics2D.Raycast(transform.position, Vector3.forward, 1, wallLayer))
        {
            spriteRenderer.color = noTP;
        } else
        {
            spriteRenderer.color = active;
        }
    }
}