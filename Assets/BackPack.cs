using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPack : MonoBehaviour
{
    public Transform Content;
    internal static Transform activeSlot;
    public Thing activeThing;

    public 

    void Start()
    {
        EventBus.AddEvent("PickupThing",PickAndShowThingAbout);
        EventBus.AddEvent("OpenBackPack", ShowNull);
        EventBus.AddEvent("TakeItem", TakeItem);
    }

    private void TakeItem(object obj)
    {
        

        if (activeSlot.childCount == 0)
        {
            GameObject icon = Instantiate((obj as RectTransform).gameObject, BackPack.activeSlot);
            DragToBackPack.ReturnIconEvent.Invoke();
            icon.transform.SetParent(BackPack.activeSlot);
            icon.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            Hide();
        }
        else
        {
            dropItem();
        }
    }

    private void dropItem()
    {
        if(activeThing!=null)
        {
            //DestroyImmediate(activeThing.gameObject);
            Destroy(activeThing.gameObject);
        }
    }

    private void PickAndShowThingAbout(object thing)
    {
        activeThing = thing as Thing;
        ScaleManager.Show("PiñkUp Content ",()=> {
            ThingAbout TA = FindObjectOfType<ThingAbout>();
            TA.Init(thing as Thing);
            ScaleManager.Show("DnDText", null);
        });
        print((thing as Thing).name);
    }
    public void Show()
    {
        ShowNull(null);
    }
    public void ShowNull(object o=null)
    {

        ScaleManager.Show("BackPack",()=>
        {
            ScaleManager.Show("BackPack Content", ShowContent);
        });
    }

    private void ShowContent()
    {
        int numslots = Content.childCount;
        Vector3 slotStartPosition = Content.GetChild(0).transform.position;
        
        for (int i = 0; i < 5-numslots; i++)
        {
            GameObject slot = Instantiate(Content.GetChild(0).gameObject, Content);
            slot.name = "Slot_" + i.ToString();
            slot.transform.position = slotStartPosition + Vector3.right * (i + 1)*120;
        }

    }

    public void Hide()
    {
        ScaleManager.Hide("BackPack",()=>
        {
            ScaleManager.Hide("BackPack Content",null);
        });
    }

    void Update()
    {

    }
}
