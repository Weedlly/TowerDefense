using UnityEngine;

public class ChampionSkillDescription: Singleton<ChampionSkillDescription>
{
    public string language = "en";

    void Start(){
        language = PlayerPrefs.GetString("Language");
    }
    
    public string skill1{
        get {
            switch(language)
            {
                case "vn": return "Hoả Kích\n\tGây sát thương diện rộng lên địch gần nhất";
                default: return "Hell Fire\n\tDeal aoe dammage too nearest enemy";
            };
        }
    }
}