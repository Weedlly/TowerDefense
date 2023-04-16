using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UpgradePanelController: MonoBehaviour
{
     User _user;
    [SerializeField] TMP_Text _titleText;
    [SerializeField] TMP_Text _star;
    void Start(){
        _user = User.Instance;
        _titleText.text = UIString.Instance.upgradeTitleText;
    }
    void Update(){
        _star.text = _user.getStar().ToString();
    }
}