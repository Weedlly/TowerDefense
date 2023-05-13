using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

/// <summary>
/// Data class for XMLSerialize 
/// </summary>

[XmlRoot(ElementName = "PlayerList")]
public class PlayerListData{
    [XmlElement(ElementName = "Player")]
    public List<PlayerData> playerlist;
    public PlayerData FindPlayerData(int playerId){
        foreach (var item in playerlist)
        {
            if(item.id == playerId){
                return item;
            }
        }
        return null;
    }
    public PlayerData FindPlayerDataByIdAndStageDifficulty(int playerId,DifficultyTypeEnum difficulty){
        foreach (var item in playerlist)
        {
            if(item.id == playerId && item.difficulty == difficulty.ToString()){
                return item;
            }
        }
        return null;
    }
}
[XmlRoot(ElementName = "Player")]
public class PlayerData{
    [XmlAttribute(AttributeName = "id")]
    public int id;
    [XmlElement(ElementName = "name")]
    public string name;
    [XmlElement(ElementName = "difficulty")]
    public string difficulty;
    [XmlElement(ElementName = "health")]
    public float health;
    [XmlElement(ElementName = "attackDame")]
    public float attackDame;
    [XmlElement(ElementName = "attackSpeed")]
    public float attackSpeed;
    [XmlElement(ElementName = "attackRange")]
    public float attackRange;
    [XmlElement(ElementName = "movementSpeed")]
    public float movementSpeed;
    [XmlElement(ElementName = "dropCoin")]
    public int dropCoin;
}





