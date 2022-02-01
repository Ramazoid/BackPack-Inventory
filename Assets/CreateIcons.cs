using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

//[ExecuteInEditMode]
public class CreateIcons : MonoBehaviour
{
    public GameObject prefab;

    public Image Icon;
    private List<Texture2D> textureList= new List<Texture2D>();
    public string path;

    // Start is called before the first frame update
    void Start()
    {
        Icon = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (prefab != null)
        {
            print("Generate");
            prefab = null;
         
        }
    }
}
