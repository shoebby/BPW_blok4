using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hover : MonoBehaviour
{
    public Texture2D defaultTextureMouse;
    public Texture2D noTeleportTextureMouse;
    public CursorMode curMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private void Start()
    {
        Cursor.SetCursor(defaultTextureMouse, hotSpot, curMode);
    }
    private void OnMouseEnter()
    {
        if (gameObject.tag == "wall")
        {
            Cursor.SetCursor(noTeleportTextureMouse, hotSpot, curMode);
        }
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(defaultTextureMouse, hotSpot, curMode);
    }
}
