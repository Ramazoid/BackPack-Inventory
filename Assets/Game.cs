using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public EventBus EB { get; private set; }

    public Texture2D handCursor;
    internal static bool isDrag;

    void Start()
    {
        
        EventBus.AddEvent("SetHand—ursor", SetHandCursor);
        EventBus.AddEvent("Clear—ursor", ClearCursor);
        


    }

    private void ClearCursor(object thing)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    private void SetHandCursor(object thing)
    {
        Cursor.SetCursor(handCursor, Vector2.zero,CursorMode.Auto);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
