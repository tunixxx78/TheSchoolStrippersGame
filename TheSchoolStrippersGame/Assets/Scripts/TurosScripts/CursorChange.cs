using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChange : MonoBehaviour
{
    public Texture2D cursorDefault, cursorSellected;
    public Vector2 hotSpot = Vector2.zero;

    private void Start()
    {
        Cursor.SetCursor(cursorDefault, hotSpot, CursorMode.ForceSoftware);
    }

    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursorSellected, hotSpot, CursorMode.ForceSoftware);
    }

    private void OnMouseOver()
    {
        Cursor.SetCursor(cursorSellected, hotSpot, CursorMode.ForceSoftware);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(cursorDefault, hotSpot, CursorMode.ForceSoftware);
    }
}
