using UnityEngine;
using System.Collections.Generic;


public class EnemyTowerDesc: Singleton<EnemyTowerDesc>
{
    public string language = "en";

    void Start(){
        language = PlayerPrefs.GetString("Language");
    }
    
   Description[] enemy_en = {
        new Description("spearman", "basic enemy"), 
        new Description("knight", "elite enemy"),
        new Description("Dark Knight", "boss enemy")
    };
    Description[] enemy_vn = {
        new Description("Lính giáo", "kẻ địch cơ bản"), 
        new Description("Kị sĩ", "kẻ đich tinh anh"),
        new Description("Hắc kị sĩ", "Trùm")
    };

    Description[] tower_en = {
        new Description("Bow tower", "+ Decent range\n+ Single target attack\n+ Low Damage\n+ High attack speed"),
        new Description("Magic tower", "+ Short range\n+ AOE attack\n + High Damage\n+ Medium attack speed"),
        new Description("Catapult tower", "+ Long range\n+ AOE attack\n + Decent Damage\n+ Low attack speed "),
        new Description("Guard tower", "+ Provide infantry to stall and attack the enemy\n+ The tower it self do not perform attack")
    };

     Description[] tower_vn = {
        new Description("Tháp cung", "+ Tầm đánh trung bình\n+ Sát thương đơn mục tiêu\n+ Sát thương thấp\n+ Tốc đánh nhanh"),
        new Description("Tháp phép", "+ Tầm đánh gần\n+ Sát thương diện rộng\n + Sát thương lớn\n+ Tốc đánh trung bình"),
        new Description("Tháp bắn đá", "+ Tầm đánh xa\n+ Sát thương diện rộng\n + Sát thương trung bình\n+ Tốc đánh chậm"),
        new Description("Tháp lính canh", "+ Sinh ra các lính để đánh lạc hướng và gây sát thương kẻ địch\n+ Bản thân trụ không gây sát thương")
    };

    public Description GetEnemyDescription(int id){
        switch (language){
            case "vn": return enemy_vn[id];
            default: return enemy_en[id];
        }
    }

    public Description GetTowerDescription(int id) {
        switch (language){
            case "vn": return tower_vn[id];
            default: return tower_en[id];
        }
    }


}