using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseCursor : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Cursor.visible = false;
    }

    void Update()
    {
        spriteRenderer.color = new Color(1f, 1f, 1f, 0f);

        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;

        if (Input.GetMouseButton(0))
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 0.35f);
        }
    }
}