using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Thing : MonoBehaviour
{
    public int weight;
    public string type;
    public string description;
    public Texture2D icon;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        EventBus.Fire("SetHand—ursor");
    }

    private void OnMouseExit()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            EventBus.Fire("Clear—ursor");
    }

    private void OnMouseDown()
    {
        EventBus.Fire("PickupThing", this);
    }
}
