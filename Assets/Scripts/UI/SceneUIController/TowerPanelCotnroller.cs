using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TowerPanelCotnroller : MonoBehaviour {
    [SerializeField] TMP_Text _languageTitle;
    void Start() {
        _languageTitle.text = UIString.Instance.towerTitle;
    }
}