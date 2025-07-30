using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D cursorNormal;
    public Vector2 normalCursorHotspot;

    public Texture2D cursorOnButton;
    public Vector2 onButtonCursorHotspot;

    private void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Cursor.SetCursor(cursorNormal, normalCursorHotspot, CursorMode.Auto);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Cursor.SetCursor(cursorOnButton, onButtonCursorHotspot, CursorMode.Auto);
        }
    }

    public void OnButtonCursorEnter()
    {
        Cursor.SetCursor(cursorOnButton, onButtonCursorHotspot, CursorMode.Auto);
    }

    public void OnButtonCursorExit()
    {
        Cursor.SetCursor(cursorNormal, normalCursorHotspot, CursorMode.Auto);
    }
}
