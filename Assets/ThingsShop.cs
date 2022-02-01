using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;
using Random = UnityEngine.Random;

public class ThingsShop : MonoBehaviour
{


    public List<GameObject> ThingPrefabs;
    [Header("Born pause in seconds")]
    public int BornPause=5;
    public int bornRadius = 2;
    public int prefabIndex;
    public TextAsset thingsXML;
    

    void Start()
    {
        
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(new StringReader(thingsXML.ToString()));
        XmlNodeList nodelist = xmlDoc.SelectNodes("//things");
        // xmlDoc.FirstChild.FirstChild.Name;
        
       

        foreach (XmlNode node in xmlDoc.FirstChild.ChildNodes)
            LoadPrefab(node);
        StartCoroutine(GiveBirth());
    }

    private void LoadPrefab(XmlNode node)
    {
        
        GameObject thing = Resources.Load(node.Name) as GameObject;
        Thing th = thing.GetComponent<Thing>();
        th.icon = Resources.Load<Texture2D>(node.Name + "_icon");
        
        th.type = node.Attributes.GetNamedItem("type").Value;
        th.weight = int.Parse(node.Attributes.GetNamedItem("weight").Value);
        th.description = node.Attributes.GetNamedItem("description").Value;
        ThingPrefabs.Add(thing);
    }

    private IEnumerator GiveBirth()
    {
        while (true&&ThingPrefabs.Count>0)
        {
            
             prefabIndex = Random.Range(0, ThingPrefabs.Count);

            GameObject newThing = Instantiate(ThingPrefabs[prefabIndex]);
            newThing.transform.position = transform.position + Random.insideUnitSphere * bornRadius;
            newThing.transform.localScale = Vector3.one * 5;
            yield return new WaitForSeconds(BornPause);
        }
    }

   
}
