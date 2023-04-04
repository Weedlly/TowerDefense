using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;


[XmlRoot(ElementName = "User")]
public class UserData{
    [XmlAttribute(AttributeName = "userId")]
    public string userId;
    [XmlElement(ElementName = "CurrentStar")]
    public int currentStar;

    [XmlArray(ElementName = "CompletetedStageList")]
    [XmlArrayItem(ElementName = "CompletetedStage")]
    public CompletetedStageData[] completetedStageList;

    [XmlArray(ElementName = "TowerUpdateList")]
    [XmlArrayItem(ElementName = "TowerUpdate")]
    public TowerUpdateData[] towerUpdateList;

    [XmlArray(ElementName = "ChampionList")]
    [XmlArrayItem(ElementName = "Champion")]
    public ChampionData[] championData;
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
}

public class ChampionData{
    [XmlAttribute(AttributeName = "championId")]
    public int championId;
    [XmlElement(ElementName = "Name")]
    public string name;
    [XmlElement(ElementName = "Level")]
    public int level;
    [XmlElement(ElementName = "ExperiencePercent")]
    public int experiencePercent;
    
}