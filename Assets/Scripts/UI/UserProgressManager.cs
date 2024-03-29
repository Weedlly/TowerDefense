using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class UserProgressManager: MonoBehaviour
{
    void Awake(){
        UIString temp = UIString.Instance;
        EnemyTowerDesc temp1 = EnemyTowerDesc.Instance;
        ChampionSkillDescription temp2 = ChampionSkillDescription.Instance;
        if (File.Exists(Application.persistentDataPath + "/" + "User.xml")){
           User user = User.Instance;
        }
        else {
            User.Instance.generateUserData();
        }
    }

    void Start() {
        Debug.Log(Application.persistentDataPath);
    }
}