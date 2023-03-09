using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingControler : MonoBehaviour
{
    // Start is called before the first frame update
    public Button _pauseBt;
    public Image _settingWindow;
    public Button _exitSettingWindowBt;
    void Start()
    {
        _pauseBt.onClick.AddListener(OpenSettingWindow);
        _exitSettingWindowBt.onClick.AddListener(TurnoffSettingWindow);
    }
    void OpenSettingWindow(){
       
        Time.timeScale = 0;
        _settingWindow.gameObject.SetActive(true);
    }
    void TurnoffSettingWindow(){
        Time.timeScale = 1;
        _settingWindow.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
