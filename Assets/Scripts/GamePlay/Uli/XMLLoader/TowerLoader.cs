using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

[XmlRoot(ElementName = "TowerList")]
public class TowerDataList{
    [XmlElement(ElementName = "Tower")]
    public List<TowerData> towerDataList;
}
[XmlRoot(ElementName = "Tower")]
public class TowerData{
    [XmlAttribute(AttributeName = "id")]
    public int id;
    [XmlElement(ElementName = "level")]
    public int level;
    [XmlElement(ElementName = "name")]
    public string name;
    [XmlElement(ElementName = "attackDame")]
    public float attackDame;
    [XmlElement(ElementName = "health")]
    public float health;
    [XmlElement(ElementName = "attackSpeed")]
    public float attackSpeed;
    [XmlElement(ElementName = "attackRange")]
    public float attackRange;
    [XmlElement(ElementName = "price")]
    public int price;
}
public class TowerLoader : MonoBehaviour
{
    private static List<TowerData> _towerDataList;
    // Start is called before the first frame update
    void Start()
    {   Debug.Log(System.IO.Directory.GetCurrentDirectory());
        Debug.Log(Application.dataPath );
        _towerDataList = TowerLoader.LoadXML<TowerDataList>(System.IO.Directory.GetCurrentDirectory() + "/Assets/XML/Tower.xml").towerDataList;
    }
    public static TowerData FindTowerData(int towerId, int towerLevel){
        foreach (var item in _towerDataList)
        {
            if(item.id == towerId && item.level == towerLevel){
                return item;
            }
        }
        return null;
    }
    public static T LoadXML<T>(string path){
        try{
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using  (var stream = new FileStream(path,FileMode.Open)){
                return (T)serializer.Deserialize(stream);
            }
        }
        catch(Exception e){
            Debug.LogError("Exception importing xml file: " + e);
            return default;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
