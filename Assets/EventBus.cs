using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBus : MonoBehaviour
{
    public Dictionary<string, Action<object>> events = new Dictionary<string, Action<object>>();
    private static EventBus INST;



    void Start()
    {
        INST = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void  AddEvent(string eventName, Action<object> EventAction)
    {
        INST.events.Add(eventName, EventAction);
        //print($"Event{eventName} Added");
    }

    internal static void Fire(string eventName,object data=null)
    {
        if (INST.events.ContainsKey(eventName))
            if(data==null)
            INST.events[eventName](null);
        else
            INST.events[eventName](data);
        else
            throw new Exception($"Event {eventName} not exist");
    }
}
