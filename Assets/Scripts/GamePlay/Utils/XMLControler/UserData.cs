using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

/// <summary>
/// Data class for XMLSerialize 
/// </summary>


[XmlRoot(ElementName = "User")]
public class UserData{
    [XmlAttribute(AttributeName = "userId")]
    public string userId;
    [XmlElement(ElementName = "Username")]
     public string username;
    [XmlElement(ElementName = "CurrentStar")]
    public int currentStar;

    [XmlArray(ElementName = "CompletetedStageList")]
    [XmlArrayItem(ElementName = "CompletetedStage")]
    public List<CompletetedStageData> completetedStageList;

    [XmlArray(ElementName = "TowerUpdateList")]//khoi update
    [XmlArrayItem(ElementName = "TowerUpdate")]//khoi update
    public List<TowerUpdateData> towerUpdateList;

    [XmlArray(ElementName = "ChampionList")]
    [XmlArrayItem(ElementName = "Champion")]
    public List<ChampionData> championData;
}

public class CompletetedStageData{
    [XmlAttribute(AttributeName = "completetedStageId")]
    public int completetedStageId;
    [XmlElement(ElementName = "Star")]
    public int star;
    [XmlElement(ElementName = "Difficulty")]
    public string difficulty;
}


public class TowerUpdateData{
    [XmlAttribute(AttributeName = "towerUpdateId")]
    public int towerUpdateId;
    [XmlElement(ElementName = "Level")]//khoi update
    public int level;
}

public class ChampionData{
    //identifier
    [XmlAttribute(AttributeName = "championId")]
    public int championId;
    [XmlElement(ElementName = "Name")]
    //exp
    public string name;
    [XmlElement(ElementName = "Level")]
    public int level;
    [XmlElement(ElementName = "CurrentExp")]
    public int currentExp;
    [XmlElement(ElementName = "ExpCap")]
    public int expCap;
    //stat
    [XmlElement(ElementName = "Health")]
    public int health;
    [XmlElement(ElementName = "AttackSpeed")]
    public float attackSpeed;
    [XmlElement(ElementName = "AttackDamage")]
    public float attackDamage;    
}