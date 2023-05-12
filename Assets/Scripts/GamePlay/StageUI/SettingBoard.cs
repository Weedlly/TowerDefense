using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class SettingBoard : MonoBehaviour {
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private TMP_Text _soundText;
    [SerializeField] private TMP_Text _musicText;
    [SerializeField] private TMP_Text _quitText;
    [SerializeField] private TMP_Text _restartText;

    void Start() {
        _titleText.text = UIString.Instance.settingTitle;
        _soundText.text = UIString.Instance.soundText;
        _musicText.text = UIString.Instance.musicText;
        _quitText.text = UIString.Instance.quitText;
        _restartText.text = UIString.Instance.restartText;
    }
}