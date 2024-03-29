using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class SettingController : MonoBehaviour
{
    /// <summary>
    /// Control Setting window, it include ( sound, gamespeed, quit, reset a stage)
    /// </summary>

    public Image _settingWindow;
    public Button _exitSettingWindowBt;
    [SerializeField] private TMP_Text _gameSpeedTxt;
    [SerializeField] private TMP_Text _backgroundSoundStatusTxt;
    [SerializeField] private TMP_Text _gameObjectSoundStatusTxt;

    void Start()
    {
        _exitSettingWindowBt.onClick.AddListener(TurnoffSettingWindow);
    }
    public void BackgroundSoundControler(){
        if(VolumeController.BackGroundMusic == true){
            TurnOffBackgroundSound();
            return;
        }
        TurnOnBackgroundSound();
    }
    void TurnOffBackgroundSound(){
        _backgroundSoundStatusTxt.text = "OFF";
        VolumeController.BackGroundMusic = false;
    }
    void TurnOnBackgroundSound(){
        _backgroundSoundStatusTxt.text = "ON";
        VolumeController.BackGroundMusic = true;
    }
    public void GameObjectSoundControler(){
        if(VolumeController.GameObjectMusic == true){
            TurnOffGameObjectSound();
            return;
        }
        TurnOnGameObjectSound();
    }
    void TurnOffGameObjectSound(){
        _gameObjectSoundStatusTxt.text = "OFF";
        VolumeController.GameObjectMusic = false;
    }
    void TurnOnGameObjectSound(){
        _gameObjectSoundStatusTxt.text = "ON";
        VolumeController.GameObjectMusic = true;
    }
    public void OpenSettingWindow(){
        Time.timeScale = 0;
        _settingWindow.gameObject.SetActive(true);
    }
    public void TurnoffSettingWindow(){
        Time.timeScale = GameControler.GAME_SPEED;
        _settingWindow.gameObject.SetActive(false);
    }
    public void RestartStage(){
        GameControler.GAME_SPEED = (float)GameSpeed.Default;
        Time.timeScale = (float)GameSpeed.Default;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitStage(){
        GameControler.GAME_SPEED = (float)GameSpeed.Default;
        Time.timeScale = (float)GameSpeed.Default;
        SceneManager.LoadScene("StageSelectScene");
    }
    public void ChangeGameSpeed(){
        switch(GameControler.GAME_SPEED){
            case (float)GameSpeed.Default:{
                GameControler.GAME_SPEED = (float)GameSpeed.Double;
                _gameSpeedTxt.text = "X" + ((int)GameControler.GAME_SPEED).ToString();
                break;
            }
            case (float)GameSpeed.Double:{
                GameControler.GAME_SPEED = (float)GameSpeed.Default;
                _gameSpeedTxt.text = "X" + ((int)GameControler.GAME_SPEED).ToString();
                break;
            }
        }
        Time.timeScale = GameControler.GAME_SPEED;
    }
}
