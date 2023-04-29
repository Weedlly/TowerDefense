using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UpgradeController: MonoBehaviour
{
    [SerializeField] int _towerId;
    User _user;
    [SerializeField] TMP_Text _upgradeText;
    [SerializeField] GameObject _level1;
    [SerializeField] GameObject _level2;
    [SerializeField] GameObject _level3;

    void Awake()
    {
        _user = User.Instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        _upgradeText.text = UIString.Instance.upgradeBtnText;
        int level = _user.getTowerLevelById(_towerId);
        if (level < 2){
            _level3.gameObject.SetActive(false);
        }
        if (level < 1){
            _level2.gameObject.SetActive(false);
        }
    } 

    public void UpgradeTower(){
        if (_user.upgradeTowerById(_towerId)){
            int level = _user.getTowerLevelById(_towerId);
            if (level == 2){
                _level3.gameObject.SetActive(true);
            }
            if (level == 1){
                _level2.gameObject.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    
}