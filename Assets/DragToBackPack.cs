using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DragToBackPack : MonoBehaviour
{
    public Texture2D dragging;
    private Transform saveparent;
    private Vector3 startmouse;
    private Vector3 startpos;
    private bool drag;
    public Transform Content;
    private Transform storeparent;
    private Vector3 storepos;
    private Vector3 storescale;
    private RectTransform RT;
    public static  UnityEvent ReturnIconEvent;

    void Start()
    {
        RT = GetComponent<RectTransform>();
        ReturnIconEvent = new UnityEvent();
        ReturnIconEvent.AddListener(ReturnIcon);
        /*
        if (storeparent!=null || storepos!=null)
        {
            ReturnIcon();
        }*/
    }
    public void CheckSlot()
    {
        print("Slot!!!!!!!!!");
    }
    public void OnMouseEnter()
    {

        Cursor.SetCursor(dragging, Vector2.zero, CursorMode.Auto);
    }
    public void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
    public void StartDrag()
    {

        startmouse = Input.mousePosition;
        startpos = transform.position;


        Game.isDrag = true;
        storeparent = transform.parent;
        storepos = transform.localPosition;
        storescale = transform.localScale;
        transform.SetParent(Content.parent);

        transform.SetSiblingIndex(Content.GetSiblingIndex() - 1);
        ScaleManager.Hide("PiñkUp Content ", () =>
        {
            transform.localScale = Vector3.one / 2;
            EventBus.Fire("OpenBackPack");
        });
    }

    public void StopDrag()
    {
        Game.isDrag = false;
        if (BackPack.activeSlot != null)
        {
            EventBus.Fire("TakeItem", transform);
            ReturnIcon();
        }




    }
    void ReturnIcon()

    {
        transform.SetParent(storeparent);
        transform.localPosition = storepos;
        transform.localScale = storescale;
    }

    void Update()
    {



        if (!Game.isDrag) return;
        Vector3 Delta = Input.mousePosition - startmouse;
        transform.position = startpos + Delta;
    }
}
            
      