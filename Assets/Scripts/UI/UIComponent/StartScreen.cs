using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public void toMainMenu(){
        GlobalValue.Instance.nextScene = 3;
        SceneManager.LoadScene(1);
    }
}
