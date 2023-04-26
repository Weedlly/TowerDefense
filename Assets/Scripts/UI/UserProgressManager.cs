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
        if (File.Exists(Application.persistentDataPath + "/" + "User.xml")){
           User user = User.Instance;
        }
        else {
            User.Instance.generateUserData();
        }
    }
}