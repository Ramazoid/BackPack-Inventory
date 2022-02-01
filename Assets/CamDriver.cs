using ExtensionMethods;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamDriver : MonoBehaviour
{
    public RectTransform canvas;
    private Vector3 deltamouse;
    private Vector3 lastmouse;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (!canvas.rect.Contains(Input.mousePosition.ToVector2())) return;
        deltamouse = Input.mousePosition - lastmouse;
        transform.Rotate(new Vector3(deltamouse.y/10, deltamouse.x/10, 0));
        lastmouse = Input.mousePosition;

        if(Input.GetMouseButton(1))
        {
            transform.Translate(transform.forward / 10);
        }
        
    }
}
