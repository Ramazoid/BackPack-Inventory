using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ThingAbout : MonoBehaviour
{
    public Image Icon;
    public Text desc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void Init(Thing thing)
    {
        
        Icon.sprite = Sprite.Create(thing.icon, new Rect(0, 0, thing.icon.width,thing.icon.height), Vector2.zero);
        desc.text ="<B>Type:</B>"+thing.type+" <B>Weight:</B>"+thing.weight+"\n"+thing.description;
    }
}
