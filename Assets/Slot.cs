using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Texture2D contains;
    private Image IM;

    void Start()
    {
        IM = GetComponent<Image>();
        IM.color = Color.black;
    }

    public void OnOver()
    {
        IM.color = Color.white;
        BackPack.activeSlot = transform;
    }

    public void OnOut()
    {
        IM.color = Color.black;
        BackPack.activeSlot = null;
    }

}
