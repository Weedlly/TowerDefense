using UnityEngine;
using System.Collections.Generic;


public class EnemyTowerDesc: Singleton<EnemyTowerDesc>
{
    public string language = "en";

    void Start(){
        language = PlayerPrefs.GetString("Language");
    }
    
   EnemyDescription[] en = {
        new EnemyDescription("spearman", "basic enemy"), 
        new EnemyDescription("knight", "elite enemy"),
        new EnemyDescription("Dark Knight", "boss enemy")
    };
    EnemyDescription[] vn = {
        new EnemyDescription("Lính giáo", "kẻ địch cơ bản"), 
        new EnemyDescription("Kị sĩ", "kẻ đich tinh anh"),
        new EnemyDescription("Hắc kị sĩ", "Trùm")
    };

    public EnemyDescription GetEnemyDescription(int id){
        switch (language){
            case "vn": return vn[id];
            default: return en[id];
        }
    }


}