using UnityEngine;
using System.Collections.Generic;


public class EnemyTowerDesc: Singleton<EnemyTowerDesc>
{
    public string language = "en";

    void Start(){
        language = PlayerPrefs.GetString("Language");
    }
    
   Description[] enemy_en = {
        new Description("Hunstress Warrior", "+ Basic enemy\n+ Lowest stat\n+ Spawn at every wave"), 
        new Description("Shield Man", "+ Elite enemy\n+ An upgrade on stat from spear man\n+ Spawn more at mid to end wave"),
        new Description("NightBorne", "+ Boss enemy\n+ High stat\n+ Have huge penalty upon entering players base\n+ Show up at finale stage")
    };
    Description[] enemy_vn = {
        new Description("Hunstress Warrior", "+ Kẻ địch cơ bản\n+ Chỉ số địch thấp\n+ Xuất hiện ở tất cả các trận"), 
        new Description("Shield Man", "+ Kẻ đich tinh anh\n+ Là nâng cấp của Hunstress Warrior\n + xuất hiện chủ yếu ở từ các trận giữa"),
        new Description("NightBorne", "+ Trùm\n+ Chỉ số cao\n+ Phạt máu nặng nếu đi vào thành ta\n+ Xuất hiện ở màn cuối")
    };

    Description[] tower_en = {
        new Description("Bow tower", "+ Decent range\n+ Single target attack\n+ Low Damage\n+ High attack speed"),
        new Description("Magic tower", "+ Short range\n+ Single target attack\n + High Damage\n+ Medium attack speed"),
        new Description("Catapult tower", "+ Long range\n+ AOE attack\n + Decent Damage\n+ Low attack speed "),
        new Description("Guard tower", "+ Provide infantry to stall and attack the enemy\n+ The tower it self do not perform attack")
    };

     Description[] tower_vn = {
        new Description("Tháp cung", "+ Tầm đánh trung bình\n+ Sát thương đơn mục tiêu\n+ Sát thương thấp\n+ Tốc đánh nhanh"),
        new Description("Tháp phép", "+ Tầm đánh gần\n+ Sát thương đơn mục tiêu\n + Sát thương lớn\n+ Tốc đánh trung bình"),
        new Description("Tháp bắn đá", "+ Tầm đánh xa\n+ Sát thương diện rộng\n + Sát thương trung bình\n+ Tốc đánh chậm"),
        new Description("Tháp lính canh", "+ Sinh ra các lính để đánh lạc hướng và gây sát thương kẻ địch\n+ Bản thân trụ không gây sát thương")
    };

    string[] tower_up_en = {
        "Tower damage up",
        "Tower atk speed up",
        "Tower range up",
        "Troop damage up",
        "Troop atk speed up",
        "Troop health up"
    };
    string[] tower_up_vn = {
        "Tăng sát thương trụ",
        "Tăng tốc đánh trụ",
        "Tăng tầm đánh trụ",
        "Tăng sát thương lính",
        "Tăng tốc đánh lính",
        "Tăng máu lính"
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

    public string GetTowerUpgradeDescription(int id) {
        switch (language){
            case "vn": return tower_up_vn[id];
            default: return tower_up_en[id];
        }
    }


}