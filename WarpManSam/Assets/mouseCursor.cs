using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseCursor : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    private Vector4 inactive;
    private Vector4 active;
    private Vector4 noTP;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Cursor.visible = false;

        inactive = new Vector4(0.5f, 0.5f, 0.5f, 0.35f);
        active = new Vector4(1f, 1f, 1f, 0.35f);
        noTP = new Vector4(1f, 0f, 0f, 0.35f);
        spriteRenderer.color = inactive;
    }

    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;

        if (Input.GetMouseButtonDown(0))
        {
            spriteRenderer.color = active;
        }

        if (Input.GetMouseButtonUp(0))
        {
            spriteRenderer.color = inactive;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            spriteRenderer.color = noTP;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            spriteRenderer.color = active;
        }
    }
}